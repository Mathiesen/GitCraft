using System.ComponentModel.DataAnnotations;

namespace Gitcraft.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Hash { get; set; }
    public string Salt { get; set; }
    public virtual List<Character> Characters { get; set; } = new List<Character>();
    
}