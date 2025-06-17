using Backend.Configurations;
using Backend.Models.Entities.Episode;
using Backend.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Backend.Services.Implementations
{
    public class EpisodeServices : IEpisodeServices
    {

        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public EpisodeServices(HttpClient httpClient, IOptions<ApiSettings> config)
        {
            _httpClient = httpClient;
            _baseUrl = config.Value.EpisodeBaseUrl;
        }

        public async Task<List<Episode>> GetEpisodes(int page = 1)
        {
             string endpoint = $"{_baseUrl}?page={page}";

            var response = await _httpClient.GetFromJsonAsync<EpisodeResponse>(endpoint);
            return response.Results;
        }
    }
}