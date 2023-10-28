namespace HCM.API.Employees.Features.Town.Requests;

using Infrastructure.Requests;

public class CreateTownRequest : BaseRequest
{
    public string Name { get; set; } = string.Empty;
}