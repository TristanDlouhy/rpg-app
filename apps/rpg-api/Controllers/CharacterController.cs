using Microsoft.AspNetCore.Mvc;

namespace RpgApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
	private readonly ILogger _logger;

	public CharacterController(ILogger<CharacterController> logger)
	{
		_logger = logger;
	}

	[HttpPost]
	public async Task<IActionResult> AddCharacter()
	{
		return Ok();
	}

}
