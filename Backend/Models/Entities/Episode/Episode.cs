using System.Text.Json.Serialization;

namespace Backend.Models.Entities.Episode
{
    public class Episode
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("air_date")]
        public string AirDate { get; set; } = string.Empty;
         [JsonPropertyName("episode")]
        public string EpisodeCode { get; set; } = string.Empty;
        public List<string> Characters { get; set; } = new();
        public string Url { get; set; } = string.Empty;
        public DateTime Created { get; set; }
    }
}