using Microsoft.EntityFrameworkCore;
using ShopBridge.Core.Entities;
using ShopBridge.Core.Repositories;

namespace ShopBridge.Data.Repositories;
public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly ShopBridgeContext _db;

    public CategoryRepository(ShopBridgeContext db) : base(db) => _db = db;

    public async Task<Category> UpdateAsync(Category category)
    {
        if (category == default)
            throw new ArgumentNullException(nameof(category));

        var dbCategory = await _db.Categories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.Id == category.Id);

        if (dbCategory != default)
        {
            dbCategory.Name = category.Name ?? dbCategory.Name;
            dbCategory.Description = category.Description ?? dbCategory.Description;
        }

        return dbCategory!;
    }
}
