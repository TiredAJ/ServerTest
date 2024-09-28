namespace ServerTest.DTOs;

public record SuperheroDTO
{
    public required string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string Place { get; set; } = string.Empty;
}
