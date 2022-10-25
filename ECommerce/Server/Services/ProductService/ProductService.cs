using ECommerce.Server.Data;
using ECommerce.Server.Services.CategoryService;
using ECommerce.Shared;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
       
        private readonly ICategoryService _categoryService;

        private readonly DataContext _context;

        public ProductService(ICategoryService categoryService, DataContext context)
        {
            _categoryService = categoryService;
            _context = context;
        }


        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            product.Views++;

            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetProductsByCategory(string categoryUrl)
        {
            var categories = await _categoryService.GetCategories();
            var categorie = categories.FirstOrDefault(c => c.Url.ToLower() == categoryUrl.ToLower());
            return _context.Products.Where(p => p.Id == categorie.Id).ToList();
        }

        public async Task<List<Product>> SearchProducts(string searchText)
        {
            return await _context.Products
                .Where(p => p.Title.Contains(searchText) || p.Description.Contains(searchText))
                .ToListAsync();
        }

        public async Task<Product> UploadProduct(Product product)
        {           
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

       
    }
}
