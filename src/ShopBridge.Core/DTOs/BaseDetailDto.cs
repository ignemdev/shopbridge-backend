namespace ShopBridge.Core.DTOs;
public abstract class BaseDetailDto : BaseDto
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
