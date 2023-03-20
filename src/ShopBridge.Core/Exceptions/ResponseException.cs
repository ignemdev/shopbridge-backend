using System.Runtime.Serialization;

namespace ShopBridge.Core.Exceptions;

[Serializable]
public sealed class ResponseException : Exception
{
    public ResponseException()
    {
        ErrorMessage = (InnerException ?? this).Message;
    }
    private ResponseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    public override void GetObjectData(SerializationInfo info, StreamingContext context) => base.GetObjectData(info, context);

    public string ErrorMessage { get; private set; } = null!;
}
