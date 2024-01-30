namespace TCGTracker.API.Entities.Models
{
    public class DeckUpdate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? TypeOneId { get; set; }
        public int? TypeTwoId { get; set; }
    }
}
