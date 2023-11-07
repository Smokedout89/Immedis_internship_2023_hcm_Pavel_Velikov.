namespace HCM.Domain.PostgresModels;

public class TownDb : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<AddressDb> Addresses { get; set; } = new HashSet<AddressDb>();
}