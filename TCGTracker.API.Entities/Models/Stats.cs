namespace TCGTracker.API.Entities.Models
{
    public class Stats
    {
        public int HighestDamage { get; set; }
        public int LowestDamage { get; set; }
        public int TotalGamesPlayed { get; set; }
        public int Wins { get; set; }
        public int Losses => TotalGamesPlayed - Wins;
        public double WinPercentage => CalculateWinPercentage();

        private double CalculateWinPercentage()
        { 
            if (TotalGamesPlayed > 0) 
            {
                return Math.Round((double)Wins / TotalGamesPlayed * 100, 2);
            }

            return 0;
        }
    }
}
