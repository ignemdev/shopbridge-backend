using System.Collections.ObjectModel;

namespace ShopBridge.Core.Entities;
public class Category : BaseEntity
{
    public Category()
    {
        Products = new Collection<Product>();
    }

    public ICollection<Product> Products { get; set; }
}
