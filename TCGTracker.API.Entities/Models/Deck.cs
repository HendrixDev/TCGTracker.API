namespace TCGTracker.API.Entities.Models
{
    public class Deck : Stats
    {
        private int _playerId;
        private int _deckId;
        private string _deckName;
        private List<Type> _deckTypes;

        public int PlayerId { get => _playerId; set => _playerId = value; }
        public int DeckId { get; set; }
        public string DeckName { get; set; }
        public List<Type> DeckTypes { get; set; } = new List<Type>();

        public Deck(int playerId, int deckId, string deckName, List<Type> deckTypes)
        {
            PlayerId = playerId;
            DeckId = deckId;
            DeckName = deckName;
            DeckTypes = deckTypes;
        }
    }
}
