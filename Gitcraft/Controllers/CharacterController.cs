using Gitcraft.DataAccess.Repository;
using Gitcraft.DataAccess.Repository.Interfaces;
using Gitcraft.Entities;
using Microsoft.AspNetCore.Authorization;
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
        return Ok();
    }

    [Authorize]
    [HttpGet("[action]")]
    public IActionResult GetCharacters()
    {
        var characters = _repository.GetCharacters();
        if (characters == null)
            _logger.Log(LogLevel.Error, "Characters not found");
        
        return Ok(characters);
    }

    [Authorize]
    [HttpGet("[action]")]
    public IActionResult GetCharacter(Guid id)
    {
        var character = _repository.GetCharacter(id);
        return Ok(character);
    }

    [HttpGet("[action]")]
    public IActionResult GetCharacterStats(Guid id)
    {
        Character character = _repository.GetCharacter(id);
        CharacterStatsModel stats = new CharacterStatsModel();
        
        stats.Health = character.Health;
        stats.Mana = character.Mana;
        stats.Stamina = character.Stamina;
        
        return Ok(stats);
    }
    
}