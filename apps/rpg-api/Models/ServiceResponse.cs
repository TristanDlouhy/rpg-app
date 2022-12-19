namespace RpgApi.Models;

public record ServiceResponse<T>
{
	public T? Data { get; set; }
	public bool Success { get; set; } = true;
	public string Message { get; set; } = string.Empty;
}
