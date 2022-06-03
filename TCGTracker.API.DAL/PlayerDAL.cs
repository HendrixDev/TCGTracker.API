using TCGTracker.API.DAL.Interface;
using TCGTracker.API.Entities.Models;

namespace TCGTracker.API.DAL
{
    public class PlayerDAL : IPlayerDAL
    {
        private readonly IMockData _mockData;

        public PlayerDAL(IMockData mockData)
        {
            _mockData = mockData;
        }

        public int CreatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public List<Player> GetAllPlayers()
        {
            return _mockData.GetMockPlayers();
        }

        public Player GetPlayerById(int id)
        {
            return _mockData.GetMockPlayers().FirstOrDefault(x => x.PlayerId == id);
        }

        public void UpdatePlayer(int id, Player player)
        {
            throw new NotImplementedException();
        }
    }
}
