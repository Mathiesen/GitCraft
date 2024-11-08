using Gitcraft.DataAccess.Repository.Interfaces;
using Gitcraft.Entities;

namespace Gitcraft.DataAccess.Repository;

public class InventoryRepository : IInventoryRepository
{
    private readonly GitCraftContext _context;
    
    public InventoryRepository(GitCraftContext dbContext)
    {
        _context = dbContext;
    }
    
    public Inventory GetInventory(Guid characterId)
    {
        var inventory = new Inventory();
        var items = _context.Items
            .Where(x => x.CharacterId == characterId);
        inventory.Items = items.ToList();
        return inventory;
    }
}