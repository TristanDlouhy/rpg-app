using System.ComponentModel.DataAnnotations;

namespace RpgApi.Models;

public record Character
{
	[Key]
	public string? Id { get; set; }
	[Required]
	public string? Name { get; set; }
	[Required]
	public int Health { get; set; } = 100;
	[Required]
	public int Strength { get; set; } = 10;
	[Required]
	public int Defence { get; set; } = 10;
	[Required]
	public int Intelligence { get; set; } = 10;
	[Required]
	public RpgClass Class { get; set; } = RpgClass.Samurai;
}
