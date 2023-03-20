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
            throw new ArgumentNullException(nameof(product), ErrorCodes.ERR1006);

        var addedProduct = await _unitOfWork.Product.AddAsync(product);
        await _unitOfWork.SaveAsync();

        var dbProduct = await _unitOfWork.Product.GetFirstOrDefaultAsync(p => p.Id == addedProduct.Id, GlobalConstants.CategoriesName);

        return dbProduct;
    }

    public async Task<Product> AddProductCategoriesAsync(int id, IEnumerable<int> categoriesIds)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), ErrorCodes.ERR1007);

        if (!(categoriesIds?.Any() ?? default))
            throw new ArgumentNullException(nameof(categoriesIds), ErrorCodes.ERR1008);

        var dbProduct = await _unitOfWork.Product.GetFirstOrDefaultAsync(p => p.Id == id, GlobalConstants.CategoriesName);

        if (dbProduct == default)
            throw new InvalidOperationException(ErrorCodes.ERR1011);

        var dbCategories = await _unitOfWork.Category.GetAllAsync(c => categoriesIds.Contains(c.Id));

        if (dbCategories.Any())
        {
            dbCategories
                .ToList()
                .ForEach(dbProduct.Categories.Add);
        }

        await _unitOfWork.SaveAsync();

        return dbProduct;
    }

    public async Task<Product> AddProductStockAsync(Product product)
    {
        if (product == default || product is Product { Stock: <= 0 })
            throw new ArgumentOutOfRangeException(nameof(product), ErrorCodes.ERR1012);

        var updatedProduct = await _unitOfWork.Product.UpdateStockAsync(product.Id, product.Stock);

        if (updatedProduct == default)
            throw new InvalidOperationException(ErrorCodes.ERR1014);

        await _unitOfWork.SaveAsync();

        return updatedProduct;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var products = await _unitOfWork.Product.GetAllAsync(orderBy: p => p.OrderByDescending(x => x.CreatedAt));
        return products;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), ErrorCodes.ERR1007);

        var dbProduct = await _unitOfWork.Product.GetFirstOrDefaultAsync(p => p.Id == id, GlobalConstants.CategoriesName);

        if (dbProduct == default)
            throw new InvalidOperationException(ErrorCodes.ERR1011);

        return dbProduct;
    }

    public async Task<Product> ReduceProductStockAsync(Product product)
    {
        if (product == default || product is Product { Stock: <= 0 })
            throw new ArgumentOutOfRangeException(nameof(product), ErrorCodes.ERR1012);

        var productId = product.Id;
        var reduceQuantity = product.Stock;

        var dbProduct = await _unitOfWork.Product.GetByIdAsync(productId);

        if (dbProduct is Product { Stock: <= 0 })
            throw new InvalidOperationException(ErrorCodes.ERR1011);

        var insufficientStock = (dbProduct.Stock - reduceQuantity) < 0;

        if (insufficientStock)
            throw new InvalidOperationException(ErrorCodes.ERR1015);

        var updatedProduct = await _unitOfWork.Product.UpdateStockAsync(productId, -reduceQuantity);

        if (updatedProduct == default)
            throw new InvalidOperationException(ErrorCodes.ERR1014);

        await _unitOfWork.SaveAsync();

        return updatedProduct;
    }

    public async Task<Product> RemoveProductByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), ErrorCodes.ERR1007);

        var dbProduct = await _unitOfWork.Product.GetFirstOrDefaultAsync(p => p.Id == id, GlobalConstants.CategoriesName);

        if (dbProduct == default)
            throw new InvalidOperationException(ErrorCodes.ERR1011);

        _unitOfWork.Product.RemoveById(id);
        await _unitOfWork.SaveAsync();

        return dbProduct;
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        if (product == default)
            throw new ArgumentNullException(nameof(product), ErrorCodes.ERR1009);

        if (product.Id <= 0)
            throw new InvalidOperationException(ErrorCodes.ERR1010);

        var updatedProduct = await _unitOfWork.Product.UpdateAsync(product);

        if (updatedProduct == default)
            throw new InvalidOperationException(ErrorCodes.ERR1014);

        await _unitOfWork.SaveAsync();

        return updatedProduct;
    }

}
