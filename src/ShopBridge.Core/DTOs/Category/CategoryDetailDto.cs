using System.Collections.ObjectModel;

namespace ShopBridge.Core.DTOs.Category;
public class CategoryDetailDto : BaseDetailDto
{
    public CategoryDetailDto()
    {
        Products = new Collection<CategoryProductListDetailDto>();
    }

    public ICollection<CategoryProductListDetailDto> Products { get; set; }
}
