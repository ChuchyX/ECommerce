using ECommerce.Shared;

namespace ECommerce.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategoryByUrl(string categoryUrl);
    }
}
