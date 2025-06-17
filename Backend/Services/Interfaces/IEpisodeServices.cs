using Backend.Models.Entities.Episode;

namespace Backend.Services.Interfaces
{
    public interface IEpisodeServices
    {
        Task<List<Episode>> GetEpisodes(int page = 1);
    }
}