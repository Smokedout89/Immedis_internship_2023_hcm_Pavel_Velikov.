namespace HCM.API.Employees.Features.Address.Responses;

public class AddressResponse
{
    public string Id { get; set; } = string.Empty;
    public string StreetName { get; set; } = string.Empty;
    public int StreetNumber { get; set; }
    public string Town { get; set; } = string.Empty;
}