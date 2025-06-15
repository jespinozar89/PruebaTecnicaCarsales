using Backend.Configurations;
using Backend.Models.Entities;
using Backend.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Backend.Services.Implementations
{
    public class RickAndMortyService : IRickAndMortyService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public RickAndMortyService(HttpClient httpClient,  IOptions<ApiSettings> config)
        {
            _httpClient = httpClient;
            _baseUrl = config.Value.RickAndMortyBaseUrl;
        }

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            string endpoint = $"{_baseUrl}/{id}";

            var response = await _httpClient.GetFromJsonAsync<Character>(endpoint);
            if (response == null)
            {
                throw new Exception($"Personaje con {id} no encontrado.");
            }
            return response;
        }

        public async Task<List<Character>> GetCharactersAsync(int page = 1)
        {   
            string endpoint = $"{_baseUrl}?page={page}";

            var response = await _httpClient.GetFromJsonAsync<CharacterResponse>(endpoint);
            return response.Results;
        }
    }
}