namespace HCM.Infrastructure.Requests;

public class BaseIdRequest : BaseRequest
{
    public string Id { get; set; } = string.Empty;
}