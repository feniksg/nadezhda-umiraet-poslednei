namespace TheMuseum.Shared.DTO;

public class LifePeriodDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public ICollection<ArtworkDTO>? Artworks { get; set; }
}
