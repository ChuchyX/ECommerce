﻿using ECommerce.Shared;

namespace ECommerce.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProductsByCategory(string categoryUrl);
        Task<Product> GetProduct(int id);
        Task<List<Product>> SearchProducts(string searchText);
        Task<Product> UploadProduct(Product product);
    }
}
