using Blazored.LocalStorage;
using Blazored.Toast.Services;
using ECommerce.Client.Services.ProductService;
using ECommerce.Shared;

namespace ECommerce.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService localStorage;
        private readonly IToastService toastService;
        private readonly IProductService productService;

        public event Action OnChange;

        public CartService(ILocalStorageService localStorage, IToastService toastService)
        {
            this.localStorage = localStorage;
            this.toastService = toastService;
        }
        public async Task AddToCart(Product product)
        {
            var cart = await localStorage.GetItemAsync<List<Product>>("cart");
            if (cart == null)
            {
                cart = new List<Product>();
            }
            cart.Add(product);
            await localStorage.SetItemAsync("cart", cart);
            toastService.ShowSuccess("Added to cart", product.Title);

            OnChange.Invoke();
        }
        public async Task<List<Product>> GetCartItems()
        {
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
    }
}
