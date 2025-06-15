using Backend.Models.Entities;

namespace Backend.Services.Interfaces
{
    public interface IRickAndMortyService
    {
        Task<List<Character>> GetCharactersAsync(int page = 1);
        Task<Character> GetCharacterByIdAsync(int id);
    }
}