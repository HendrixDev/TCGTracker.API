using TCGTracker.API.Entities.Models;

namespace TCGTracker.API.DAL.Interface
{
    public interface IDeckDAL
    {
        Task<IEnumerable<Deck>> GetAllDecksByPlayerId(int playerId);
        Task<Deck> GetDeckById(int id);
        Task<int> CreateDeck(Deck deck);
        Task<bool> UpdateDeck(int id, DeckUpdate update);
        Task<bool> DeleteDeck(int id);
    }
}
