using System.Security.Cryptography;
using System.Text;
using Gitcraft.DataAccess.Repository.Interfaces;
using Gitcraft.Entities;
using Gitcraft.Util;
using Microsoft.AspNetCore.Mvc;

namespace Gitcraft.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _userRepository;
    private HashUtil _hashUtil;
    

    public UserController(ILogger<UserController> logger, IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
        _hashUtil = new HashUtil();
    }

    [HttpPost("[action]")]
    public IActionResult RegisterUser(string username, string password)
    {
        var hashNSalt = _hashUtil.GenerateHash(password);
        
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = username,
            Salt = hashNSalt.salt,
            Hash = hashNSalt.hash
        };
        
        _userRepository.RegisterUser(user);

        return Ok();
    }

    [HttpPost("[action]")]
    public IActionResult VerifyUser(string username, string password)
    {
        var user = _userRepository.GetUser(username);

        var hashNSalt = _hashUtil.GenerateHash(password);
        
        var validPassword = CryptographicOperations.FixedTimeEquals(
            Convert.FromBase64String(hashNSalt.hash), 
            Convert.FromBase64String(user.Hash));

        if (validPassword)
            return Ok();
        else
            return Unauthorized();
    }
    
}