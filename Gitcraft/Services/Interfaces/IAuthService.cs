using Gitcraft.Entities;

namespace Gitcraft.Services.Interfaces;

public interface IAuthService
{
    bool VerifyLogin(string username, string password);
}