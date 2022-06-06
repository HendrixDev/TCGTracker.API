using Dapper;
using TCGTracker.API.Context;
using TCGTracker.API.DAL.Interface;
using TCGTracker.API.Entities.Models;

namespace TCGTracker.API.DAL
{
    public class PlayerDAL : IPlayerDAL
    {
        private readonly IMockData _mockData;
        private readonly DapperContext _context;

        public PlayerDAL(IMockData mockData, DapperContext context)
        {
            _mockData = mockData;
            _context = context;
        }

        public int CreatePlayer(Player player)
        {
            return player.PlayerId;
        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            var query = "SELECT * FROM Players";
            using var connection = _context.CreateConnection();
            var players = await connection.QueryAsync<Player>(query);
            return players.ToList();
        }

        public Player GetPlayerById(int id)
        {
            return _mockData.GetMockPlayers().FirstOrDefault(x => x.PlayerId == id);
        }

        public bool UpdatePlayer(int id, Player player)
        {
            throw new NotImplementedException();
        }
    }
}
