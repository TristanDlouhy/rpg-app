using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Dtos;
using RpgApi.Models;

namespace RpgApi.Services;

public class CharacterService : ICharacterService
{
	private readonly IMapper _mapper;
	private readonly DataContext _context;

	public CharacterService(
		IMapper mapper,
		DataContext context)
	{
		_mapper = mapper;
		_context = context;
	}

	public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
	{
		var response = new ServiceResponse<List<GetCharacterDto>>();
		var characters = await _context.Characters.ToListAsync();
		response.Data = characters
			.Select(c => _mapper.Map<GetCharacterDto>(c))
			.ToList();

		return response;
	}

	public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(CreateCharacterDto newCharacter)
	{
		var response = new ServiceResponse<List<GetCharacterDto>>();
		var character = _mapper.Map<Character>(newCharacter);
		_context.Characters.Add(character);
		await _context.SaveChangesAsync();

		response.Data = await _context.Characters
			.Select(c => _mapper.Map<GetCharacterDto>(c))
			.ToListAsync();

		return response;
	}
}
