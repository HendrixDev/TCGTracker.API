using Dapper;
using TCGTracker.API.Context;
using TCGTracker.API.DAL.Interface;
using TCGTracker.API.Entities.Models;

namespace TCGTracker.API.DAL
{
    public class PlayerDAL : IPlayerDAL
    {
        private readonly DapperContext _context;

        public PlayerDAL(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePlayer(Player player)
        {
            //TODO: add query to create player
            var query = "";
            using var connection = _context.CreateConnection();
            var playerId = await connection.QueryAsync<int>(query);
            return playerId.FirstOrDefault();
        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            var query = "SELECT * FROM Players";
            using var connection = _context.CreateConnection();
            var players = await connection.QueryAsync<Player>(query);
            return players.ToList();
        }

        public async Task<Player> GetPlayerById(int id)
        {
            var query = $"SELECT TOP 1 * FROM Players WHERE PlayerId = {id}";
            using var connection = _context.CreateConnection();
            var player = await connection.QueryAsync<Player>(query);
            return player.First();
        }

        public async Task<bool> UpdatePlayer(int id, Player player)
        {
            try
            {
                //TODO: write query to update Player by Id
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
