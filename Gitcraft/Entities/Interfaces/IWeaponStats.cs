namespace Gitcraft.Entities.Interfaces;

public interface IWeaponStats
{
    int Durability { get; set; }
    int Damage { get; set; }
    int Strength { get; set; }
    int Speed { get; set; }
    int Accuracy { get; set; }
    int Range { get; set; }
    int Intelligence { get; set; }
}