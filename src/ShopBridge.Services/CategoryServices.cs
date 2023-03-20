using ShopBridge.Core;
using ShopBridge.Core.Entities;
using ShopBridge.Core.Services;

namespace ShopBridge.Services;
public class CategoryServices : ICategoryServices
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryServices(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Category> AddCategoryAsync(Category category)
    {
        if (category == default)
            throw new ArgumentNullException(nameof(category));

        var addedCategory = await _unitOfWork.Category.AddAsync(category);
        await _unitOfWork.SaveAsync();

        var dbCategory = await _unitOfWork.Category.GetFirstOrDefaultAsync(c => c.Id == addedCategory.Id, "Products");

        return dbCategory;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        var categories = await _unitOfWork.Category.GetAllAsync(orderBy: p => p.OrderByDescending(x => x.CreatedAt));
        return categories;
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        var dbCategory = await _unitOfWork.Category.GetFirstOrDefaultAsync(c => c.Id == id, "Products");

        if (dbCategory == default)
            throw new NullReferenceException(nameof(dbCategory));

        return dbCategory;
    }

    public async Task<Category> RemoveCategoryByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        var dbCategory = await _unitOfWork.Category.GetFirstOrDefaultAsync(c => c.Id == id, "Products");

        if (dbCategory == default)
            throw new NullReferenceException(nameof(dbCategory));

        _unitOfWork.Category.RemoveById(id);
        await _unitOfWork.SaveAsync();

        return dbCategory;
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        if (category == default)
            throw new ArgumentNullException(nameof(category));

        if (category.Id <= 0)
            throw new ArgumentOutOfRangeException(nameof(category.Id));

        var updatedCategory = await _unitOfWork.Category.UpdateAsync(category);

        if (updatedCategory == default)
            throw new NullReferenceException(nameof(updatedCategory));

        await _unitOfWork.SaveAsync();

        return updatedCategory;
    }
}
