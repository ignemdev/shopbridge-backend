using System.Collections.ObjectModel;

namespace ShopBridge.Core.Entities;
public class Product : BaseEntity
{
    public Product()
    {
        Categories = new Collection<Category>();
    }

    public int Stock { get; set; }
    public float Price { get; set; }

    public ICollection<Category> Categories { get; set; }
}
