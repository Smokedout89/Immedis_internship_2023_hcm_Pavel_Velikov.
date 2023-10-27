namespace HCM.Infrastructure.Responses;

public class BaseResponse
{
    public BaseResponse(ResponseStatus responseStatus)
    {
        ResponseStatus = responseStatus;
    }

    public ResponseStatus ResponseStatus { get; set; }
}