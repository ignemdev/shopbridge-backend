using ShopBridge.Core.Entities;

namespace ShopBridge.Core.Services;
public interface ICategoryServices
{
    Task<Category> AddCategoryAsync(Category category);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task<Category> RemoveCategoryByIdAsync(int id);
    Task<Category> UpdateCategoryAsync(Category category);
}
