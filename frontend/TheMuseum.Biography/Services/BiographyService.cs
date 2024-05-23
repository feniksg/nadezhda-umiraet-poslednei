using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using TheMuseum.Biography.Models;


namespace TheMuseum.Biography.Services
{
    public class ApiClient : HttpClient
    {
        public ApiClient()
        {
            // Настройте HttpClient здесь, если необходимо
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetAsync<T>(string requestUri)
        {
            var response = await base.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest data)
        {
            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var response = await base.PostAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(responseData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string requestUri, TRequest data)
        {
            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var response = await base.PutAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(responseData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task DeleteAsync(string requestUri)
        {
            var response = await base.DeleteAsync(requestUri);
            response.EnsureSuccessStatusCode();
        }
    }

    internal class BiographyService
    {

        // Написать производный класс от HTTPClient, который имеет GET, POST, PUT, DELETE, обобщенные методы 
        private readonly ApiClient _apiClient;

        private readonly string baseUrl = "https://vocal-guppy-hideously.ngrok-free.app/";
        public BiographyService(ApiClient apiClient)
        {
            _apiClient = apiClient;

        }
        public async Task<List<ArtworkModel>> GetArtworksAsync()
        {
            return await _apiClient.GetAsync<List<ArtworkModel>>($"{baseUrl}api/artworks");
        }

        public async Task AddArtworkAsync(ArtworkModel artwork)
        {
            await _apiClient.PostAsync<ArtworkModel, ArtworkModel>($"{baseUrl}api/artworks", artwork);
        }

        public async Task UpdateArtworkAsync(ArtworkModel artwork)
        {
            await _apiClient.PutAsync<ArtworkModel, ArtworkModel>($"{baseUrl}api/artworks/{artwork.Id}", artwork);
        }

        public async Task DeleteArtworkAsync(int artworkId)
        {
            await _apiClient.DeleteAsync($"{baseUrl}api/artworks/{artworkId}");
        }
    }
    //public ICollection<ArtworkModel> GetArtworks()
    //    {
    //        // TODO client.GetAsync(...)
    //        return new ArtworkModel[]
    //        {
    //            new ArtworkModel
    //            {
    //              Id = 1, Title = "Раннее детство и юность Василия Верещагина: первые шаги в искусстве.",
    //                Description = "14 (26) октября. Родился в Череповце в семье уездного предводителя" +
    //                "дворянства Василия Васильевича Верещагина (1806–1879), и Анны Николаевны Верещагиной " +
    //                "(урожд. Жеребцовой, 1819–1881).\n" +
    //                "Василий Верещагин начал заниматься искусством еще в раннем детстве. В юности он посещал " +
    //                "мастерские местных художников и изучал основы живописи."
    //            },
    //            new ArtworkModel
    //            {
    //              Id = 2, Title = "Обучение Верещагина в Императорской академии художеств и начало его творческого пути.",
    //                Description = "Награжден серебряной медалью Получает серебряную медаль второй степени за эскиз дипломной " +
    //                "работы «Избиение женихов Пенелопы возвратившимся Улиссом» (1861–1862, Государственный Русский музей), " +
    //                "переносит его на большой картон в технике сепии.\n" +
    //                "В 1863 году Верещагин поступил в Императорскую академию художеств, где изучал живопись и гравюру. После окончания " +
    //                "обучения он начал свое творческое путешествие."
    //            },
    //            new ArtworkModel
    //            {
    //                Id = 3, Title = "Первые успешные выставки Верещагина и узнаваемый стиль его работ.",
    //                Description = "В 1870-х годах Верещагин начал выставлять свои работы и получил признание как художник-пейзажист. " +
    //                "Его узнаваемый стиль выражался в яркой красочности и тщательной проработке деталей.\n" +
    //                "Отправляется в командировку за границу для систематизации накопленного материала и подготовки альбома картин " +
    //                "Туркестанского края (издан в 1874 с названием «Туркестан. Этюды с натуры В.В. Верещагина»)."
    //            }
    //        };
    //    }
    //}
}
