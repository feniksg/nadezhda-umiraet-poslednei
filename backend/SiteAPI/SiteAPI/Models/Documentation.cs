namespace SiteAPI.Models
{
    public class Documentation
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string DocumentType { get; set; }
        public int AccessLevel { get; set; }
    }

}
