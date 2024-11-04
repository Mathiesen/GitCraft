using Gitcraft.DataAccess.Repository.Interfaces;
using Gitcraft.Entities;

namespace Gitcraft.DataAccess.Repository;

public class UserRepository : IUserRepository
{
    private readonly GitCraftContext _context;

    public UserRepository(GitCraftContext context)
    {
        _context = context;
    }
    
    public void RegisterUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User? GetUser(string username)
    {
        return _context.Users.FirstOrDefault(user => user.Username == username);
    }
}