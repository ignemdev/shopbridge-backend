using ShopBridge.Core.Entities;

namespace ShopBridge.Core.Repositories;
public interface IProductRepository : IRepository<Product>
{
    Task<Product> UpdateAsync(Product product);
    Task<Product> UpdateStockAsync(int id, int stock);
}
