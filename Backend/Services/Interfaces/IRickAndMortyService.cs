using Backend.Models.Entities;

namespace Backend.Services.Interfaces
{
    public interface IRickAndMortyService
    {
        Task<List<Character>> GetCharactersAsync(int page = 1);
        Task<List<Character>> GetCharactersByNameAsync(string name);
        Task<Character> GetCharacterByIdAsync(int id);
    }
}