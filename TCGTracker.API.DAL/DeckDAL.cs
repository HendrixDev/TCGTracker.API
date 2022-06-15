using Dapper;
using TCGTracker.API.Context;
using TCGTracker.API.DAL.Interface;
using TCGTracker.API.Entities.Models;

namespace TCGTracker.API.DAL
{
    public class DeckDAL : IDeckDAL
    {
        private readonly DapperContext _context;

        public DeckDAL(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateDeck(int playerId, Deck deck)
        {
            //TODO: add query to create deck
            var query = "";
            using var connection = _context.CreateConnection();
            var deckId = await connection.QueryFirstOrDefaultAsync<int>(query);
            return deckId;
        }

        public async Task<IEnumerable<Deck>> GetAllDecksByPlayerId(int playerId)
        {
            var query = $"SELECT * FROM Decks WHERE PlayerId = {playerId}";
            using var connection = _context.CreateConnection();
            var decks = await connection.QueryAsync<Deck>(query);
            return decks.ToList();
        }

        public async Task<Deck> GetDeckById(int id)
        {
            var query = $"SELECT TOP 1 * FROM Decks WHERE Id = {id}";
            using var connection = _context.CreateConnection();
            var deck = await connection.QueryFirstOrDefaultAsync<Deck>(query);
            return deck;
        }

        public async Task<bool> UpdateDeck(int id, Deck deck)
        {
            try
            {
                //TODO: write query to update Deck by Id
                var query = "";
                using var connection = _context.CreateConnection();
                await connection.ExecuteAsync(query);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
