namespace TCGTracker.API.Entities.Models
{
    public class Player : Stats
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public List<Deck> Decks { get; set; } = new List<Deck>();
    }
}
