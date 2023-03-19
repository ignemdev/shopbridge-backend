﻿using ShopBridge.Core.Entities;

namespace ShopBridge.Core.Services;
public interface IProductServices
{
    Task<Product> AddProductAsync(Product product);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task<Product> RemoveProductById(int id);
    Task<Product> UpdateProduct(Product product);
}