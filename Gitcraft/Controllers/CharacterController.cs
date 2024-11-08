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
    private readonly ICharacterRepository _characterRepository;
    private readonly IInventoryRepository _inventoryRepository;

    public CharacterController(ILogger<CharacterController> logger, 
        ICharacterRepository characterRepository, IInventoryRepository inventoryRepository)
    {
        _logger = logger;
        _characterRepository = characterRepository;
        _inventoryRepository = inventoryRepository;
    }

    [HttpPost("[action]")]
    public IActionResult Create(Character character)
    {
        _characterRepository.AddCharacter(character);
        return Ok();
    }

    [Authorize]
    [HttpGet("[action]")]
    public IActionResult GetCharacters()
    {
        var characters = _characterRepository.GetCharacters();
        if (characters == null)
            _logger.Log(LogLevel.Error, "Characters not found");
        
        return Ok(characters);
    }

    [Authorize]
    [HttpGet("[action]")]
    public IActionResult GetCharacter(Guid id)
    {
        var character = _characterRepository.GetCharacter(id);
        return Ok(character);
    }

    [HttpGet("[action]")]
    public IActionResult GetCharacterStats(Guid id)
    {
        Character character = _characterRepository.GetCharacter(id);
        CharacterStatsModel stats = new CharacterStatsModel();
        
        stats.Health = character.Health;
        stats.Mana = character.Mana;
        stats.Stamina = character.Stamina;
        
        return Ok(stats);
    }

    [HttpGet("[action]")]
    public IActionResult GetInventory(Guid characterId)
    {
        Inventory inventory = _inventoryRepository.GetInventory(characterId);
        return Ok(inventory);
    }
    
}