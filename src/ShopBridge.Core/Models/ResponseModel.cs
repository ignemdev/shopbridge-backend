namespace ShopBridge.Core.Models;
public class ResponseModel<TModel> where TModel : class
{
    public TModel Data { get; set; } = default!;
    public string ErrorMessage { get; private set; } = null!;
    public bool HasError { get; private set; }
    public void SetData(TModel data)
    {
        if (data != default)
            Data = data;
    }

    public void SetErrorMessage(string message)
    {
        ErrorMessage = message;
        HasError = true;
    }
}
