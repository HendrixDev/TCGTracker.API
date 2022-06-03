namespace TCGTracker.API.Entities.Models
{
    public class Match
    {
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public int PlayerTwoDamage { get; set; }
        public int PlayerOneDamage { get; set; }
        public Deck PlayerOneDeck { get; set; }
        public Deck PlayerTwoDeck { get; set; }
        public string Winner { get; set; }
        public DateTime MatchDate { get; set; }
    }
}
