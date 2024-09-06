using Gitcraft.Entities;

namespace Gitcraft.DataAccess.Repository;

public interface ICharacterRepository
{
    void AddCharacter(Character character);
    IList<Character> GetCharacters();
}