namespace Bibliotekarz.App.Model;

public record CustomerDto
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}