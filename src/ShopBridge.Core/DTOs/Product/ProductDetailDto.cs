using System.Collections.ObjectModel;

namespace ShopBridge.Core.DTOs.Product;
public class ProductDetailDto : BaseDetailDto
{
    public ProductDetailDto()
    {
        Categories = new Collection<ProductCategoryListDetailDto>();
    }

    public int Stock { get; set; }
    public float Price { get; set; }

    public ICollection<ProductCategoryListDetailDto> Categories { get; set; }
}
