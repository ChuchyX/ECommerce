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
    }
}
