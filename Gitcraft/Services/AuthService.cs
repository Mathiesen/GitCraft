using System.Security.Cryptography;
using Gitcraft.DataAccess.Repository;
using Gitcraft.DataAccess.Repository.Interfaces;
using Gitcraft.Entities;
using Gitcraft.Services.Interfaces;
using Gitcraft.Util;

namespace Gitcraft.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private HashUtil _hashUtil;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _hashUtil = new HashUtil();
    }
    
    public bool VerifyLogin(string username, string password)
    {
        var user = _userRepository.GetUser(username);

        if (user == null)
            return false;

        return _hashUtil.VerifyHash(password, user.Hash, user.Salt);
    }
}