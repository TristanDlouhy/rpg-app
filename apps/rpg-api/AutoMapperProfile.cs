using AutoMapper;
using RpgApi.Dtos;
using RpgApi.Models;

namespace RpgApi;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		CreateMap<Character, GetCharacterDto>();
		CreateMap<CreateCharacterDto, Character>();
		CreateMap<UpdateCharacterDto, Character>();
	}
}
