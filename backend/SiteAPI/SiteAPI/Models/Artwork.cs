using System.ComponentModel.DataAnnotations.Schema;

namespace SiteAPI.Models
{
    public class Artwork
    {
        public int Id { get; set; }
         
        public string Title {  get; set; }
        public string Description { get; set; }

    }
}
