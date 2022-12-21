using System.Text.Json.Serialization;
using RpgApi.Models;

namespace RpgApi.Dtos;

public record UpdateCharacterDto
{
	[JsonRequired]
	public string Id { get; set; } = Guid.NewGuid().ToString();
	public string Name { get; set; } = "";
	public int Health { get; set; } = 100;
	public int Strength { get; set; } = 10;
	public int Defence { get; set; } = 10;
	public int Intelligence { get; set; } = 10;
	public RpgClass Class { get; set; } = RpgClass.Samurai;
}

