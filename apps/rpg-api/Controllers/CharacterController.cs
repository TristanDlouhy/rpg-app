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

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteCharacter(string id)
	{
		var response = await _characterService.DeleteCharacter(id);

		if (response.Data is null)
		{
			return NotFound(response);
		}

		return Ok(response);
	}

	[HttpPut]
	public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updateCharacter)
	{
		var response = await _characterService.UpdateCharacter(updateCharacter);

		if (response.Data is null)
		{
			return NotFound(response);
		}

		return Ok(response);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> Get(string id)
	{
		return Ok(await _characterService.GetCharacterBy(id));
	}

	[HttpGet("get-all")]
	public async Task<IActionResult> GetAll()
	{
		return Ok(await _characterService.GetAllCharacters());
	}
}
