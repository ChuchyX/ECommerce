using ECommerce.Shared;

namespace ECommerce.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(Product product);
    }
}
