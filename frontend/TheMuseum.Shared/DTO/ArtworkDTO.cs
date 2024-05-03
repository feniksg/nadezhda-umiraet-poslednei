using System.ComponentModel.DataAnnotations.Schema;

namespace TheMuseum.Shared.DTO;

public class ArtworkDTO
{
    public int Id { get; set; }
    public int YearCreated { get; set; }
    public string? Series { get; set; }
    public string? Genre { get; set; }
    public required string ImageFilePath { get; set; } // Путь к файлу в папке media

    //для свяхи с периодом жизни
    public int LifePeriodId { get; set; }//внешний ключ 
    public LifePeriodDTO? LifePeriod { get; set; }//для программы чтобы обращаться Artwork.LifePeriod

}
