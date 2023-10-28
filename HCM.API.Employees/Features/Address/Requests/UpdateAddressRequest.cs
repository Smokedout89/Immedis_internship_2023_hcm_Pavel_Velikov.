namespace HCM.API.Employees.Features.Address.Requests;

using Infrastructure.Requests;

public class UpdateAddressRequest : BaseIdRequest
{
    public string StreetName { get; set; } = string.Empty;
    public int StreetNumber { get; set; }
}