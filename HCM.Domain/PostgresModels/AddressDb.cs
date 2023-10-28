namespace HCM.Domain.PostgresModels;

using System.ComponentModel.DataAnnotations.Schema;

public class AddressDb : BaseEntity
{
    public string StreetName { get; set; } = string.Empty;
    public int StreetNumber { get; set; }

    [ForeignKey(nameof(TownDb))]
    public string TownId { get; set; } = string.Empty;
    public virtual TownDb Town { get; set; } = null!;
}