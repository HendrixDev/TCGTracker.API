using TCGTracker.API.Entities.Models;

namespace TCGTracker.API.DAL.Interface
{
    public interface IPlayerDAL
    {
        Task<IEnumerable<Player>> GetAllPlayers();
        Player GetPlayerById(int id);
        int CreatePlayer(Player player);
        bool UpdatePlayer(int id, Player player);
    }
}
