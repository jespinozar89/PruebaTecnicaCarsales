namespace Backend.Models.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public LocationInfo Origin { get; set; } = new LocationInfo();
        public LocationInfo Location { get; set; } = new LocationInfo();
        public string Image { get; set; } = string.Empty;
        public List<string> Episode { get; set; } = new();
        public string Url { get; set; } = string.Empty;
        public DateTime Created { get; set; }
    }
}