using System.Security.Cryptography;
using System.Text;
using Gitcraft.DataAccess.Repository.Interfaces;
using Gitcraft.Entities;
using Gitcraft.Services.Interfaces;
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
    private readonly IAuthService _authService;


    public UserController(ILogger<UserController> logger, IUserRepository userRepository, IAuthService authService)
    {
        _logger = logger;
        _userRepository = userRepository;
        _hashUtil = new HashUtil();
        _authService = authService;
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

        var validPassword = _authService.VerifyLogin(username, password);

        if (validPassword)
            return Ok();
        else
            return Unauthorized();
    }
    
}