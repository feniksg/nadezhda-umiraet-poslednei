namespace SiteAPI.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        public int YearCreated { get; set; }
        public string? Series { get; set; }
        public string? Genre { get; set; }
        public required string ImageFilePath { get; set; } // Путь к файлу в папке media
        public int PeriodOfLifeId { get; set; }
    }
}
