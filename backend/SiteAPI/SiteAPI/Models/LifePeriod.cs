namespace SiteAPI.Models
{
    public class LifePeriod
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
