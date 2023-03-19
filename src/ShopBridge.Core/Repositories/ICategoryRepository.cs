using ShopBridge.Core.Entities;

namespace ShopBridge.Core.Repositories;
public interface ICategoryRepository : IRepository<Category>
{
    Task<Category> UpdateAsync(Category category);
}
