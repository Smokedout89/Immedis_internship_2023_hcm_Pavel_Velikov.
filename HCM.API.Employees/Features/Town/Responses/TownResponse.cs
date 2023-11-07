namespace HCM.API.Employees.Features.Town.Responses;

using Domain.Abstractions.Models;

public class TownResponse
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<Address> Addresses { get; set; } = new();
}