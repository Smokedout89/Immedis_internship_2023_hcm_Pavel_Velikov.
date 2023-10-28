namespace HCM.API.Employees.Features.Address.Requests;

using Infrastructure.Requests;

public class CreateAddressRequest : BaseRequest
{
    public string StreetName { get; set; } = string.Empty;
    public int StreetNumber { get; set; }
    public string TownId { get; set; } = string.Empty;
}