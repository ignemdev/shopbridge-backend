using ShopBridge.Core;
using ShopBridge.Core.Entities;
using ShopBridge.Core.Services;

namespace ShopBridge.Services;
public class ProductServices : IProductServices
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductServices(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Product> AddProductAsync(Product product)
    {
        if (product == default)
            throw new ArgumentNullException(nameof(product));

        var addedProduct = await _unitOfWork.Product.AddAsync(product);
        await _unitOfWork.SaveAsync();

        var dbProduct = await _unitOfWork.Product.GetFirstOrDefaultAsync(p => p.Id == addedProduct.Id, "Categories");

        return dbProduct;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var products = await _unitOfWork.Product.GetAllAsync(orderBy: p => p.OrderByDescending(x => x.CreatedAt));
        return products;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        var dbProduct = await _unitOfWork.Product.GetFirstOrDefaultAsync(p => p.Id == id, "Categories");

        if (dbProduct == default)
            throw new NullReferenceException(nameof(dbProduct));

        return dbProduct;
    }

    public async Task<Product> RemoveProductByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        var dbProduct = await _unitOfWork.Product.GetFirstOrDefaultAsync(p => p.Id == id, "Categories");

        if (dbProduct == default)
            throw new NullReferenceException(nameof(dbProduct));

        _unitOfWork.Product.RemoveById(id);
        await _unitOfWork.SaveAsync();

        return dbProduct;
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        if (product == default)
            throw new ArgumentNullException(nameof(product));

        if (product.Id <= 0)
            throw new ArgumentOutOfRangeException(nameof(product.Id));

        var updatedProduct = await _unitOfWork.Product.UpdateAsync(product);

        if (updatedProduct == default)
            throw new NullReferenceException(nameof(updatedProduct));

        await _unitOfWork.SaveAsync();

        return updatedProduct;
    }

}
