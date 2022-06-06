namespace TCGTracker.API.Entities.Models
{
    public class Match
    {
        public string? MatchNotes { get; set; }
        public string? Winner { get; set; }
        public DateTime MatchDate { get; set; }
        public List<Tuple<Player, int>> PlayersAndDamageValues { get; set; }
    }
}
