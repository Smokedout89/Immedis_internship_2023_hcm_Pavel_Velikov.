namespace HCM.Infrastructure.Requests;

public class BasePagedRequest : BaseRequest
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
}