using Gitcraft.DataAccess.Repository;
using Gitcraft.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gitcraft.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ILogger<CharacterController> _logger;
    private readonly ICharacterRepository _repository;

    public CharacterController(ILogger<CharacterController> logger, ICharacterRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpPost("[action]")]
    public IActionResult Create(Character character)
    {
        _repository.AddCharacter(character);
        return Ok("Character created");
    }

    [HttpGet("[action]")]
    public IActionResult GetCharacters()
    {
        return Ok(_repository.GetCharacters());
    }
    
}