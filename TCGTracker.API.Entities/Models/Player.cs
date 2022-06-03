namespace TCGTracker.API.Entities.Models
{
    public class Player : Stats
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public List<Deck> Decks { get; set; } = new List<Deck>();
    }
}
