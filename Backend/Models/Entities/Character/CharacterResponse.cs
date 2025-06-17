namespace Backend.Models.Entities
{
    public class CharacterResponse
    {
        public Info Info { get; set; } = new();
        public List<Character> Results { get; set; } = new();
    }

}