using Gitcraft.Entities;

namespace Gitcraft.DataAccess.Repository.Interfaces;

public interface IUserRepository
{
    void RegisterUser(User user);
    User? GetUser(string username);
    User? GetUser(Guid userId);
}