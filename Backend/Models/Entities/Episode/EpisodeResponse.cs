namespace Backend.Models.Entities.Episode
{
    public class EpisodeResponse
    {
        public Info Info { get; set; } = new();
        public List<Episode> Results { get; set; } = new();
    }

}