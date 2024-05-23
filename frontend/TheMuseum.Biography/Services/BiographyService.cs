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

        public async Task<List<ArtworkModel>> GetSearchedArtworksAsync(string query)
        {
            return await _apiClient.GetAsync<List<ArtworkModel>>($"{baseUrl}api/artworks/?search={query}");
        }
    }
}
