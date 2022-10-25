using Blazored.LocalStorage;
using Blazored.Toast.Services;
using ECommerce.Client.Services.ProductService;
using ECommerce.Shared;
using System.Net.Http.Json;

namespace ECommerce.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService localStorage;
        private readonly IToastService toastService;
        private readonly HttpClient http;

        public event Action OnChange;

        public CartService(ILocalStorageService localStorage, IToastService toastService, HttpClient http)
        {
            this.localStorage = localStorage;
            this.toastService = toastService;
            this.http = http;
        }
        public async Task AddToCart(Product product)
        {
            var cart = await localStorage.GetItemAsync<List<Product>>("cart");
            if (cart == null)
            {
                cart = new List<Product>();
            }
            var encontrado = false;
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Id==product.Id)
                {
                    cart[i].Quantity++;
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                cart.Add(product);
            }
           
            await localStorage.SetItemAsync("cart", cart);
            toastService.ShowSuccess("Added to cart", product.Title);

            OnChange.Invoke();
        }
        public async Task<List<Product>> GetCartItems()
        {
            //obtener de AuthController del metodo get que manda el cartItems del usuario
            var cart = await localStorage.GetItemAsync<List<Product>>("cart");
            if (cart == null)
            {
                return new List<Product>();
            }
            return cart;
        }

        public async Task DeleteItem(Product product)
        {
            var cart = await localStorage.GetItemAsync<List<Product>>("cart");
            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(x => x.Id == product.Id);
            cart.Remove(cartItem);

            await localStorage.SetItemAsync("cart", cart);
            OnChange.Invoke();
        }

        public async Task EmptyCart()
        {
            await localStorage.RemoveItemAsync("cart");
            OnChange.Invoke();
        }

        public async Task<string> Checkout()
        {
            var result = await http.PostAsJsonAsync("api/Payment/checkout", await GetCartItems());
            var url = await result.Content.ReadAsStringAsync();
            return url;
        }
    }
}
