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
            throw new ArgumentNullException(nameof(category), ErrorCodes.ERR1001);

        var addedCategory = await _unitOfWork.Category.AddAsync(category);
        await _unitOfWork.SaveAsync();

        var dbCategory = await _unitOfWork.Category.GetFirstOrDefaultAsync(c => c.Id == addedCategory.Id, GlobalConstants.ProductsName);

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
            throw new ArgumentOutOfRangeException(nameof(id), ErrorCodes.ERR1002);

        var dbCategory = await _unitOfWork.Category.GetFirstOrDefaultAsync(c => c.Id == id, GlobalConstants.ProductsName);

        if (dbCategory == default)
            throw new InvalidOperationException(ErrorCodes.ERR1003);

        return dbCategory;
    }

    public async Task<Category> RemoveCategoryByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        var dbCategory = await _unitOfWork.Category.GetFirstOrDefaultAsync(c => c.Id == id, GlobalConstants.ProductsName);

        if (dbCategory == default)
            throw new InvalidOperationException(ErrorCodes.ERR1004);

        _unitOfWork.Category.RemoveById(id);
        await _unitOfWork.SaveAsync();

        return dbCategory;
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        if (category == default)
            throw new ArgumentNullException(nameof(category), ErrorCodes.ERR1001);

        if (category.Id <= 0)
            throw new InvalidOperationException(ErrorCodes.ERR1002);

        var updatedCategory = await _unitOfWork.Category.UpdateAsync(category);

        if (updatedCategory == default)
            throw new InvalidOperationException(ErrorCodes.ERR1005);

        await _unitOfWork.SaveAsync();

        return updatedCategory;
    }
}
