using Gitcraft.Entities;

namespace Gitcraft.DataAccess.Repository.Interfaces;

public interface ICharacterRepository
{
    void AddCharacter(Character character);
    IList<Character> GetCharacters();
    Character GetCharacter(Guid id);
}