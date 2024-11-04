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

    public AuthController(ILogger<AuthController> logger, IAuthService authService, JwtTokenUtil jwtTokenUtil)
    {
        _logger = logger;
        _authService = authService;
        _jwtTokenUtil = jwtTokenUtil;
    }

    [HttpPost("[action]")]
    public IActionResult Login(LoginModel model)
    {
        if (_authService.VerifyLogin(model.Username, model.Password))
        {
            var token = _jwtTokenUtil.GenerateToken(model.Username);
            return Ok(new {token});
        }
        else
        {
            return Unauthorized();
        }
    }
    
}