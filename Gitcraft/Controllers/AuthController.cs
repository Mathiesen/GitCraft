using System.Text.Json;
using System.Text.Json.Serialization;
using Gitcraft.DataAccess.Repository.Interfaces;
using Gitcraft.Entities;
using Gitcraft.Services.Interfaces;
using Gitcraft.Util;
using Microsoft.AspNetCore.Mvc;

namespace Gitcraft.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;
    private JwtTokenUtil _jwtTokenUtil;
    private readonly IUserRepository _userRepository;

    public AuthController(ILogger<AuthController> logger, 
        IAuthService authService, JwtTokenUtil jwtTokenUtil, IUserRepository userRepository)
    {
        _logger = logger;
        _authService = authService;
        _jwtTokenUtil = jwtTokenUtil;
        _userRepository = userRepository;
    }

    [HttpPost("[action]")]
    public IActionResult Login(LoginModel model)
    {
        if (_authService.VerifyLogin(model.Username, model.Password))
        {
            var user = _userRepository.GetUser(model.Username);
            var token = _jwtTokenUtil.GenerateToken(model.Username);
            
            return Ok(new {token, user.Id});
        }
        else
        {
            return Unauthorized();
        }
    }
    
}