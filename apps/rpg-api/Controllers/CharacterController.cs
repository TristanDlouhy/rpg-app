using Microsoft.AspNetCore.Mvc;
using RpgApi.Dtos;
using RpgApi.Services;

namespace RpgApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
	private readonly ILogger _logger;
	private ICharacterService _characterService;

	public CharacterController(
		ILogger<CharacterController> logger,
		ICharacterService characterService)
	{
		_logger = logger;
		_characterService = characterService;
	}

	[HttpPost]
	public async Task<IActionResult> AddCharacter(CreateCharacterDto newCharacter)
	{
		return Ok(await _characterService.AddCharacter(newCharacter));
	}
	{
		return Ok();
	}

	[HttpGet("get-all")]
	public async Task<IActionResult> GetAll()
	{
		return Ok(await _characterService.GetAllCharacters());
	}
}
