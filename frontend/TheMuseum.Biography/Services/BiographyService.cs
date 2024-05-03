using System.Net.Http;
using TheMuseum.Biography.Models;

namespace TheMuseum.Biography.Services
{
    internal class BiographyService
    {
        public BiographyService(HttpClient client)
        {
            // Написать производный класс от HTTPClient, который имеет GET, POST, PUT, DELETE, обобщенные методы 
        }

        public ICollection<ArtworkModel> GetArtworks()
        {
            // TODO client.GetAsync(...)
            return new ArtworkModel[]
            {
                new ArtworkModel
                {
                  Id = 1, Name = "Default", Description = "Lorem"
                },
                new ArtworkModel
                {
                  Id = 2, Name = "New", Description = "New Lorem"
                }
            };
        }
    }
}
