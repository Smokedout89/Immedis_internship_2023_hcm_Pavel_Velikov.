namespace HCM.Infrastructure.Requests;

using System.Text.Json.Serialization;

public class BaseIdRequest : BaseRequest
{
    [JsonIgnore]
    public string Id { get; set; } = string.Empty;
}