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
            //TODO: add query to create match
            var query = "";
            using var connection = _context.CreateConnection();
            var matchId = await connection.QueryFirstOrDefaultAsync<int>(query);
            return matchId;
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
                //TODO: write query to update Match by Id
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
