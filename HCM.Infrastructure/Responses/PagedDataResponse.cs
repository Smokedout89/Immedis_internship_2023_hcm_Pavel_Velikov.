namespace HCM.Infrastructure.Responses;

public class PagedDataResponse<T> : DataResponse<List<T>> where T : class
{
    public PagedDataResponse(
        List<T> payload,
        PageMetadata pageInfo,
        ResponseStatus responseStatus)
        : base(payload, responseStatus)
    {
        PageInfo = pageInfo;
    }

    public PageMetadata PageInfo { get; set; }
}