namespace Gitcraft.Entities;

public class UserModel
{
    public virtual ICollection<Character> Characters { get; set; }
}