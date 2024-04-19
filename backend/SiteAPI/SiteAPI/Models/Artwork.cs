using System.ComponentModel.DataAnnotations.Schema;

namespace SiteAPI.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        public int YearCreated { get; set; }
        public string? Series { get; set; }
        public string? Genre { get; set; }
        public required string ImageFilePath { get; set; } // Путь к файлу в папке media
<<<<<<< Updated upstream
         
        //для свяхи с периодом жизни
        public int LifePeriodId { get; set; }//внешний ключ 
        public LifePeriod? LifePeriod { get; set; }//для программы чтобы обращаться Artwork.LifePeriod
=======

        public int LifePeriodId { get; set; }
        public LifePeriod LifePeriod { get; set; }
>>>>>>> Stashed changes
    }
}
