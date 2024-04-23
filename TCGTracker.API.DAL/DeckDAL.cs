using Dapper;
using Microsoft.VisualBasic;
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

        public async Task<int> CreateDeck(Deck deck)
        {
            var query = "INSERT INTO Decks(Name, TotalGamesPlayed, Wins, HighestDamage, LowestDamage, PlayerId, Description) " +
                        "VALUES(@Name, @TotalGamesPlayed, @Wins, @HighestDamage, @LowestDamage, @PlayerId, @Description)";
            using var connection = _context.CreateConnection();
            int rowsAffected = await connection.ExecuteAsync(query, deck);
            return rowsAffected;
        }

        public async Task<IEnumerable<Deck>> GetAllDecksByPlayerId(int playerId)
        {
            var query = $"SELECT d.*, t1.TypeName AS TypeOne, t2.TypeName AS TypeTwo " +
                        $"FROM Decks d " +
                        $"LEFT JOIN [dbo].[Types] AS t1 ON t1.TypeId = d.TypeOneTypeId " +
                        $"LEFT JOIN [dbo].[Types] AS t2 ON t2.TypeId = d.TypeTwoTypeId " +
                        $"WHERE PlayerId = {playerId}";
            using var connection = _context.CreateConnection();
            var decks = await connection.QueryAsync<Deck>(query);
            return decks.ToList();
        }

        public async Task<Deck> GetDeckById(int id)
        {
            var query = $"SELECT TOP 1 d.*, t1.TypeName AS TypeOne, t2.TypeName AS TypeTwo " +
                        $"FROM Decks d " +
                        $"LEFT JOIN [dbo].[Types] AS t1 ON t1.TypeId = d.TypeOneTypeId " +
                        $"LEFT JOIN [dbo].[Types] AS t2 ON t2.TypeId = d.TypeTwoTypeId " +
                        $"WHERE DeckID = {id}";
            using var connection = _context.CreateConnection();
            var deck = await connection.QueryFirstOrDefaultAsync<Deck>(query);
            return deck;
        }

        public async Task<bool> UpdateDeck(int id, Deck deck)
        {
            try
            {
                var query = $"UPDATE Decks " +
                            $"SET Name = @Name, Description = @Description, TypeOneTypeId = @TypeOneId, TypeTwoTypeId =  @TypeTwoId " +
                            $"WHERE DeckID = {id}";
                using var connection = _context.CreateConnection();
                await connection.ExecuteAsync(query, deck);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteDeck(int id)
        {
            try
            {
                var query = $"DELETE FROM Decks WHERE DeckID = {id}";
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
