namespace ShopBridge.Core.DTOs;
public abstract class BaseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}
