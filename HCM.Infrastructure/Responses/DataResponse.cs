namespace HCM.Infrastructure.Responses;

public class DataResponse<T> : BaseResponse
{
    public DataResponse(T payload, ResponseStatus responseStatus)
        : base(responseStatus)
    {
        Payload = payload;
    }

    public T Payload { get; set; }
}