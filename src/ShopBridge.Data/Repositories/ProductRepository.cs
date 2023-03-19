using Microsoft.EntityFrameworkCore;
using ShopBridge.Core.Entities;
using ShopBridge.Core.Repositories;

namespace ShopBridge.Data.Repositories;
public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly ShopBridgeContext _db;
    public ProductRepository(ShopBridgeContext db) : base(db) => _db = db;

    public async Task<Product> UpdateAsync(Product product)
    {
        if (product == default)
            throw new ArgumentNullException(nameof(product));

        var dbProduct = await _db.Products
            .Include(p => p.Categories)
            .FirstOrDefaultAsync(p => p.Id == product.Id);

        if (dbProduct != default)
        {
            dbProduct.Name = product.Name ?? dbProduct.Name;
            dbProduct.Description = product.Description ?? dbProduct.Description;
            dbProduct.Price = product.Price;
        }

        return dbProduct!;
    }
}
