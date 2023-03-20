namespace ShopBridge.Core.Models
{
    public class ResponseModel<TData>
        where TData : class
    {
        public TData Data { get; set; } = null!;
        public string ErrorMessage { get; private set; } = null!;
        public bool HasError { get; protected set; }
        public void SetData(TData data)
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

    public class ResponseModel<TData, TError> : ResponseModel<TData>
        where TData : class
        where TError : class
    {
        public ResponseModel()
        {
            ValidationErrors = new List<TError>();
        }

        public List<TError> ValidationErrors { get; private set; }

        public void SetValidationErrors(List<TError> validationErrors)
        {
            if (validationErrors?.Any() ?? default)
            {
                HasError = true;
                ValidationErrors.AddRange(validationErrors);
            }
        }
    }
}
