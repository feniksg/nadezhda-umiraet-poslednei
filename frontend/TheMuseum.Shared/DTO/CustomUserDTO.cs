namespace TheMuseum.Shared.DTO;

public class CustomUserDTO
{
    public int Id { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Patronymic { get; set; }
    public required string Position { get; set; }
    public int AccessLevel { get; set; }
}
