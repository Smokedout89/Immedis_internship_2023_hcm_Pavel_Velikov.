namespace HCM.Web.Responses;

public class AddressResponse : BaseResponse<AddressPayload>
{
}

public class AddressPayload
{
    public string Id { get; set; } = string.Empty;
    public string StreetName { get; set; } = string.Empty;
    public int StreetNumber { get; set; }
}