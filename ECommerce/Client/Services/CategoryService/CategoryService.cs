using ECommerce.Shared;
using System.Net.Http.Json;

namespace ECommerce.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient http;
        public List<Category> Categories { get; set; } = new List<Category>();

        public CategoryService(HttpClient http)
        {
            this.http = http;
        }

        public async Task LoadCategories()
        {
            Categories = await http.GetFromJsonAsync<List<Category>>("api/category");
        }

        public async Task<Category> GetCategoryByUrl(string categoryUrl)
        {
            await LoadCategories();

            return Categories.FirstOrDefault(c => c.Url.ToLower().Equals(categoryUrl.ToLower()));
            
        }
    }
}
