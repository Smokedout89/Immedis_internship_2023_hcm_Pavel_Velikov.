namespace HCM.Domain.Abstractions;

using System.Text.Json.Serialization;

public class Model
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [JsonIgnore]
    public DateTime CreatedOn { get; init; } = DateTime.UtcNow;
}