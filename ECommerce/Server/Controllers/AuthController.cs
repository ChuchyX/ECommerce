using ECommerce.Server.Data;
using ECommerce.Server.Services.UserService;
using ECommerce.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        private readonly DataContext _context;

        public AuthController(IConfiguration configuration, IUserService userService, DataContext context)
        {
            _configuration = configuration;
            _userService = userService;           
            _context = context;
        }



        [HttpGet, Authorize]
        public ActionResult<string> GetMe()
        {
            var userName = _userService.GetMyName();
            return Ok(userName);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserLoginDto request)
        {
            var listaUsers = _context.Users.ToList();

            bool encontrado = listaUsers.Any(u => u.Username == request.Username && VerifyPasswordHash(request.Password, u.PasswordHash, u.PasswordSalt));
       
            if (encontrado)
            {
                return BadRequest("Sorry, there is already a user with your username and password!!!");
            }
            else
            {
                CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

                var user = new User();

                user.Username = request.Username;
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(user);
            }          
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLoginDto request)
        {
            var listaUsers = _context.Users.ToList();

            var usuario = new User();
            bool encontrado = false;

            foreach (var user in listaUsers)
            {
                if (user.Username == request.Username && VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                {
                    usuario = user;
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                return BadRequest("User Not Found. Wrong Username or Password");
            }
            else
            {
                string token = CreateToken(usuario);

               
                SetRefreshToken(token, usuario);

                return Ok(token);
            }         
        }



    

    
      
        private void SetRefreshToken(string token, User user)
        {         
            user.RefreshToken = token;
            user.TokenCreated = DateTime.Now;
            user.TokenExpires = DateTime.Now.AddDays(7);

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        private string CreateToken(User user)
        {
            string role = "Buyer";
            if(user.Username == "Chuchy" && VerifyPasswordHash("*ChuchyX11", user.PasswordHash, user.PasswordSalt))
            {
                role = "Admin";
            }
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }


    }
}
