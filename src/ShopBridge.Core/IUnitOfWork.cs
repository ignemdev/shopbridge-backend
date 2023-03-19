namespace ShopBridge.Core;
public interface IUnitOfWork
{
    Task SaveAsync();
}
