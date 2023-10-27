namespace HCM.Infrastructure.Responses;

public class PageMetadata
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
}