using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RpgApi.Controllers;
using RpgApi.Dtos;
using RpgApi.Models;
using RpgApi.Services;

namespace RpgApi.Test;

public class CharacterControllerTest
{
	private CharacterController? _controller;
	private Fixture _fixture;
	private Mock<ICharacterService> _mockService;
	private Mock<ILogger<CharacterController>> _mockLogger;

	public CharacterControllerTest()
	{
		_fixture = new Fixture();
		_mockLogger = new Mock<ILogger<CharacterController>>();
		_mockService = new Mock<ICharacterService>();
	}

	[Fact]
	public async Task POST_AddCharacter_OK()
	{
		var newCharacter = _fixture.Create<CreateCharacterDto>();
		var characters = _fixture.CreateMany<GetCharacterDto>(3).ToList();

		var response = new ServiceResponse<List<GetCharacterDto>>();
		response.Data = characters;

		_mockService.Setup(s => s.AddCharacter(newCharacter))
			.ReturnsAsync(response);

		_controller = new CharacterController(
			_mockLogger.Object,
			_mockService.Object
		);

		var result = await _controller.AddCharacter(newCharacter);
		var objectResult = result as ObjectResult;
		var resultResponse = objectResult?.Value as ServiceResponse<List<GetCharacterDto>>;

		Assert.Equal(200, objectResult?.StatusCode);
		Assert.Equal(response, resultResponse);
		Assert.Equal(3, resultResponse?.Data?.Count);
	}

	[Fact]
	public async Task GET_AllCharacters_OK()
	{
		var characters = _fixture.CreateMany<GetCharacterDto>(20).ToList();

		var response = new ServiceResponse<List<GetCharacterDto>>();
		response.Data = characters;

		_mockService.Setup(s => s.GetAllCharacters())
			.ReturnsAsync(response);

		_controller = new CharacterController(
			_mockLogger.Object,
			_mockService.Object
		);

		var result = await _controller.GetAll();
		var objectResult = result as ObjectResult;
		var resultResponse = objectResult?.Value as ServiceResponse<List<GetCharacterDto>>;

		Assert.Equal(200, objectResult?.StatusCode);
		Assert.Equal(response, resultResponse);
		Assert.Equal(20, resultResponse?.Data?.Count);
	}
}
