namespace HCM.Domain.PostgresModels;

using System.ComponentModel.DataAnnotations.Schema;

public class AddressDb : BaseEntity
{
    [ForeignKey(nameof(TownDb))]
    public string TownId { get; set; } = string.Empty;
    public virtual TownDb Town { get; set; } = null!;
}