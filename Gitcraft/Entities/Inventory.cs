using Gitcraft.Entities.Interfaces;

namespace Gitcraft.Entities;

public class Inventory
{
    public IList<Item> Items { get; set; } = new List<Item>();
}