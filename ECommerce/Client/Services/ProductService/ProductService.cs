using ECommerce.Shared;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace ECommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient http;
        public List<Product> Products { get; set; } = new List<Product>();

        public ProductService(HttpClient http)
        {
            this.http = http;   
        }

        public async Task LoadProducts(string categoryUrl = null)
        {
            if (categoryUrl == null)
            {
                Products = await http.GetFromJsonAsync<List<Product>>("api/Product");
            }
            else
            {
                Products = await http.GetFromJsonAsync<List<Product>>($"api/Product/Category/{categoryUrl}");
            }
        }

        public async Task<Product> GetProduct(int id)
        {
            return await http.GetFromJsonAsync<Product>($"api/Product/{id}");
        }

        public async Task<List<Product>> SearchProducts(string searchText)
        {
            return await http.GetFromJsonAsync<List<Product>>($"api/Product/Search/{searchText}");
        }
    }
}
