using Gitcraft.Entities;

namespace Gitcraft.DataAccess.Repository.Interfaces;

public interface IInventoryRepository
{
    Inventory GetInventory(Guid characterId);
}