namespace TCGTracker.API.Entities.Models
{
    public class Deck : Stats
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Type> DeckTypes { get; set; } = new List<Type>();
    }
}
