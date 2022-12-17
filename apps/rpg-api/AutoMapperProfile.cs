using AutoMapper;
using RpgApi.Dtos;
using RpgApi.Models;

namespace rpgapi;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		CreateMap<CreateCharacterDto, Character>();
	}
}
