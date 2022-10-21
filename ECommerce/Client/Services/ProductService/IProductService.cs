using ECommerce.Shared;

namespace ECommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        public List<Product> Products { get; set; }
        Task LoadProducts(string categoryUrl = null);
        Task<Product> GetProduct(int id);
    }
}
