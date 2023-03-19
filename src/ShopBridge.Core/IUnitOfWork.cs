using ShopBridge.Core.Repositories;

namespace ShopBridge.Core;
public interface IUnitOfWork
{
    ICategoryRepository Category { get; }
    IProductRepository Product { get; }
    Task SaveAsync();
}
