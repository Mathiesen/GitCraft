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
    public Guid? UserId { get; set; }
}