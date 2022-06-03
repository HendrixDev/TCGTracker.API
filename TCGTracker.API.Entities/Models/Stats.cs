namespace TCGTracker.API.Entities.Models
{
    public class Stats
    {
        public int TotalGamesPlayed { get; set; }
        public int HighestDamage { get; set; }
        public int LowestDamage { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public double WinLoseRatio { get; set; } 
    }
}
