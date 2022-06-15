using TCGTracker.API.Entities.Models;

namespace TCGTracker.API.DAL.Interface
{
    public interface IPlayerDAL
    {
        Task<IEnumerable<Player>> GetAllPlayers();
        Task<Player> GetPlayerById(int id);
        Task<int> CreatePlayer(Player player);
        Task<bool> UpdatePlayer(int id, Player player);
    }
}
