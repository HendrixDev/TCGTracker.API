using Dapper;
using TCGTracker.API.Context;
using TCGTracker.API.DAL.Interface;
using TCGTracker.API.Entities.Models;

namespace TCGTracker.API.DAL
{
    public class MatchDAL : IMatchDAL
    {
        private readonly DapperContext _context;

        public MatchDAL(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateMatch(Match Match)
        {
            var query = "INSERT INTO Matches(PlayerOne, PlayerTwo, PlayerOneDamage, PlayerTwoDamage, PlayerOneDeck, PlayerTwoDeck, Winner, Date, Notes) " +
                                     "VALUES(@PlayerOne, @PlayerTwo, @PlayerOneDamage, @PlayerTwoDamage, @PlayerOneDeck, @PlayerTwoDeck, @Winner, @Date, @Notes)"; 
            using var connection = _context.CreateConnection();
            int rowsAffected = await connection.ExecuteAsync(query, Match);
            return rowsAffected;
        }

        public async Task<IEnumerable<Match>> GetAllMatchesByPlayerId(int playerId)
        {
            var query = $"SELECT * FROM Matches WHERE PlayerId = {playerId}";
            using var connection = _context.CreateConnection();
            var matches = await connection.QueryAsync<Match>(query);
            return matches.ToList();
        }

        public async Task<Match> GetMatchById(int id)
        {
            var query = $"SELECT TOP 1 * FROM Matches WHERE Id = {id}";
            using var connection = _context.CreateConnection();
            var match = await connection.QueryFirstOrDefaultAsync<Match>(query);
            return match;
        }

        public async Task<bool> UpdateMatch(int id, Match match)
        {
            try
            {
                var query = $"UPDATE Matches " +
                            $"SET PlayerOne = @PlayerOne, " +
                            $"PlayerTwo = @PlayerTwo, " +
                            $"PlayerOneDamage = @PlayerOneDamage, " +
                            $"PlayerTwoDamage =  @PlayerTwoDamage, " +
                            $"PlayerOneDeck = @PlayerOneDeck, " +
                            $"PlayerTwoDeck = @PlayerTwoDeck, " +
                            $"Winner = @Winner, " +
                            $"Notes = @Notes " +
                            $"WHERE MatchId = {id}";
                using var connection = _context.CreateConnection();
                await connection.ExecuteAsync(query, match);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteMatch(int id)
        {
            try
            {
                var query = $"DELETE FROM Matches WHERE MatchID = {id}";
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
