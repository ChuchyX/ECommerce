using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared
{
    public class UserLoginDto
    {
        [Required]
        [NotNull]
        public string Username { get; set; } = string.Empty;
        [Required]
        [NotNull]
        public string Password { get; set; } = string.Empty;
    }
}
