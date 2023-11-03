namespace HCM.Web.Responses;

using Infrastructure.Responses;

public class BaseResponse<T>
{
    public T Payload { get; set; } = default!;
    public ResponseStatus ResponseStatus { get; set; } = null!;
}