using ECommerce.Shared;

namespace ECommerce.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(Product product);
        Task<List<Product>> GetCartItems();
        Task DeleteItem(Product item);
        Task EmptyCart();
        Task<string> Checkout();
    }
}
