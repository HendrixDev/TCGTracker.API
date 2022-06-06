namespace TCGTracker.API.Entities.Models
{
    public class Deck : Stats
    {
        public int PlayerId { get; set; }
        public int DeckId { get; set; }
        public string DeckName { get; set; }
        public string Description { get; set; }
        public List<Type> DeckTypes { get; set; } = new List<Type>();
    }
}
