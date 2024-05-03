namespace TheMuseum.Shared.DTO;

public class EventInfoDTO
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string EventType { get; set; }
    public required List<DateTime> EventDates { get; set; }
    public bool IsCurrent { get; set; }
    public string? Organizer { get; set; }
    public bool IsOnline { get; set; }
    public bool IsFree { get; set; }
}
