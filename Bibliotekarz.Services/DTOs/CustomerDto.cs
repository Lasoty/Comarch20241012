namespace Bibliotekarz.Services.DTOs;

public record CustomerDto
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}