namespace HCM.Web.Responses;

public class TownResponse : BaseResponse<TownPayload>
{
}

public class TownPayload
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}