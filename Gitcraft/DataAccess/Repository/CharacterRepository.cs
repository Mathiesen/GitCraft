using Gitcraft.DataAccess.Repository.Interfaces;
using Gitcraft.Entities;

namespace Gitcraft.DataAccess.Repository;

public class CharacterRepository : ICharacterRepository
{
    private readonly GitCraftContext _context;
    
    public CharacterRepository(GitCraftContext dbContext)
    {
        _context = dbContext;
    }
    
    public void AddCharacter(Character character)
    {
        _context.Characters.Add(character);
        _context.SaveChanges();
    }

    public IList<Character> GetCharacters()
    {
        return _context.Characters.ToList();
    }

    public Character GetCharacter(Guid id)
    {
        var inventory = _context.Items.Where(x => x.CharacterId == id);
        var character = _context.Characters.Where(x => x.Id == id).FirstOrDefault();
        character.Inventory.Items = inventory.ToList();
        return character;
    }
}