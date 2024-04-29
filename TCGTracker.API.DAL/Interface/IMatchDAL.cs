using TCGTracker.API.Entities.Models;

namespace TCGTracker.API.DAL.Interface
{
    public interface IMatchDAL
    {
        Task<IEnumerable<Match>> GetAllMatches();
        Task<IEnumerable<Match>> GetAllMatchesByPlayerId(int playerId);
        Task<Match> GetMatchById(int id);
        Task<int> CreateMatch(Match Match);
        Task<bool> UpdateMatch(int id, Match Match);
        Task<bool> DeleteMatch(int id);
    }
}
