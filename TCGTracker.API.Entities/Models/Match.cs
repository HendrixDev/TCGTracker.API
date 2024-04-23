namespace TCGTracker.API.Entities.Models
{
    public class Match
    {
        public int MatchID { get; set; }
        public string PlayerOne { get; set; }
        public int PlayerOneDamage { get; set; }
        public string PlayerOneDeck { get; set; }
        public string PlayerTwo { get; set; }
        public int PlayerTwoDamage { get; set; }
        public string PlayerTwoDeck { get; set; }
        public string? Winner { get; set; }
        public DateTime Date { get; set; }
        public string? Notes { get; set; }
    }
}
