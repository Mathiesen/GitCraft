using Gitcraft.Entities.Interfaces;

namespace Gitcraft.Entities.Weapons;

public class Sword : Weapon
{
    public Guid Id { get; }
    public string Name { get; }
    public string ItemType { get; }

    public Sword(string name)
    {
        Name = name;
        ItemType = "Sword";
        Id = Guid.NewGuid();
    }

    public override void Attack()
    {
        throw new NotImplementedException();
    }

    public override void Defend()
    {
        throw new NotImplementedException();
    }
}