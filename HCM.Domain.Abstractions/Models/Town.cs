namespace HCM.Domain.Abstractions.Models;

public class Town : Model
{
    public string Name { get; set; } = string.Empty;
    public List<Address> Addresses { get; set; } = new();
}