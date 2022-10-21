using ECommerce.Shared;

namespace ECommerce.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        List<Category> Categories { get; set; }
        Task LoadCategories();
    }
}
