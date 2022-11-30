using System.Text.Json.Serialization;

namespace RpgApi.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RpgClass
{
	Samurai = 1,
	Monk = 2,
	Ninja = 3,
	Dragoon = 4,
	BalckMage = 5,
	Summoner = 6,
	RedMage = 7,
	WhiteMage = 8
}
