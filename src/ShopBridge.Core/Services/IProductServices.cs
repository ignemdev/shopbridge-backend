﻿using ShopBridge.Core.Entities;

namespace ShopBridge.Core.Services;
public interface IProductServices
{
    Task<Product> AddProductAsync(Product product);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task<Product> RemoveProductByIdAsync(int id);
    Task<Product> UpdateProductAsync(Product product);
    Task<Product> AddProductCategoriesAsync(int id, IEnumerable<int> categoriesIds);
    Task<Product> AddProductStockAsync(Product product);
    Task<Product> ReduceProductStockAsync(Product product);
}
