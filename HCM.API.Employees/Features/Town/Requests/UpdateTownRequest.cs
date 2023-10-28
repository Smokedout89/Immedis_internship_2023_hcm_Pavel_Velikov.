namespace HCM.API.Employees.Features.Town.Requests;

using Infrastructure.Requests;

public class UpdateTownRequest : BaseIdRequest
{
    public string Name { get; set; } = string.Empty;
}