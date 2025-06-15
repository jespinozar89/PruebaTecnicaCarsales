namespace Backend.Models.Entities
{
    public class CharacterResponse
    {
        public Info Info { get; set; } = new();
        public List<Character> Results { get; set; } = new();
    }

    public class Info
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public string? Next { get; set; }
        public string? Prev { get; set; }
    }

}