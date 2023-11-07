namespace HCM.Web.Models;

public class AddressCreateModel
{
    public string StreetName { get; set; } = string.Empty;
    public int StreetNumber { get; set; }
    public string TownId { get; set; } = string.Empty;
}