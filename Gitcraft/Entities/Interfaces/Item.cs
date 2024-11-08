using System.ComponentModel.DataAnnotations;

namespace Gitcraft.Entities.Interfaces;

public class Item
{
    [Key]
    public Guid Id { get; set; }
    public Guid CharacterId { get; set; }
    public string Name { get; set; }
    public string ItemType { get; set; }
}