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

        public int CreatePlayer(Player player)
        {
            //var query = "SELECT * FROM Players";
            //using var connection = _context.CreateConnection();
            //var players = await connection.QueryAsync<Player>(query);
            //return players.ToList();
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

        public bool UpdatePlayer(int id, Player player)
        {
            throw new NotImplementedException();
        }
    }
}
