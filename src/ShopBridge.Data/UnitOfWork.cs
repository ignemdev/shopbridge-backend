using ShopBridge.Core;
using ShopBridge.Core.Repositories;
using ShopBridge.Data.Repositories;

namespace ShopBridge.Data;
public class UnitOfWork : IUnitOfWork
{
    private readonly ShopBridgeContext _db;
    public UnitOfWork(ShopBridgeContext db)
    {
        _db = db;
        Category = new CategoryRepository(db);
        Product = new ProductRepository(db);

    }
    public ICategoryRepository Category { get; private set; }
    public IProductRepository Product { get; private set; }
    public async Task SaveAsync() => await _db.SaveChangesWithTimestampsAsync();
}
