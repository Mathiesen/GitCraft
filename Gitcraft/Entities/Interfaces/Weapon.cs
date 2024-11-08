namespace Gitcraft.Entities.Interfaces;

public abstract class Weapon : Item, IWeaponStats
{
    public int Durability { get; set; }
    public int Damage { get; set; }
    public int Strength { get; set; }
    public int Speed { get; set; }
    public int Accuracy { get; set; }
    public int Range { get; set; }
    public int Intelligence { get; set; }

    public abstract void Attack();

    public abstract void Defend();

}