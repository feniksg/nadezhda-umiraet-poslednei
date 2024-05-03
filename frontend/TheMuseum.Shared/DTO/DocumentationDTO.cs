namespace TheMuseum.Shared.DTO;

public class DocumentationDTO
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string DocumentType { get; set; }
    public int AccessLevel { get; set; }
}
