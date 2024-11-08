using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Gitcraft.Entities.Interfaces;

namespace Gitcraft.Entities;

public class Character
{
    public Guid Id {get; set;}
    public string Name { get; set; }
    public string Class { get; set; }
    public string Race { get; set; }
    public string? Image { get; set; }
    public int? Health { get; set; }
    public int? Mana { get; set; }
    public int? Stamina { get; set; }
    public int? Level { get; set; }
    public Guid? UserId { get; set; }
    [JsonIgnore]
    public User User { get; set; }
    [NotMapped]
    public Inventory Inventory { get; set; }
}