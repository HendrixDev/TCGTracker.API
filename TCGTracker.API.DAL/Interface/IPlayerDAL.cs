using TCGTracker.API.Entities.Models;

namespace TCGTracker.API.DAL.Interface
{
    public interface IPlayerDAL
    {
        List<Player> GetAllPlayers();
        Player GetPlayerById(int id);
        int CreatePlayer(Player player);
        void UpdatePlayer(int id, Player player);
    }
}
