using RpgApi.Dtos;
using RpgApi.Models;

namespace RpgApi.Services;

public interface ICharacterService
{
	Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(CreateCharacterDto newCharacter);
}
