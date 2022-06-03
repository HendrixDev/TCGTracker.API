using TCGTracker.API.Entities.Models;

namespace TCGTracker.API.DAL.Interface
{
    public interface IMockData
    {
        List<Player> GetMockPlayers();
    }
}
