using Microsoft.AspNetCore.Mvc;
using TCGTracker.API.DAL.Interface;
using TCGTracker.API.Entities.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TCGTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        //fields
        private readonly ILogger<PlayerController> _logger;
        private readonly IPlayerDAL _playerDAL; 

        //constructor
        public PlayerController(ILogger<PlayerController> logger, IPlayerDAL playerDAL)
        {
            _logger = logger;
            _playerDAL = playerDAL;
        }

        // GET: api/<PlayerController>
        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            try
            {
                _logger.Log(LogLevel.Information, message: "Getting all players");
                var players = await _playerDAL.GetAllPlayers();
                return Ok(players);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<PlayerController>/5
        [HttpGet("{id}")]
        public IActionResult GetPlayerById(int id)
        {
            _logger.Log(LogLevel.Information, message: "Getting player with ID: {0}", id);
            var player = _playerDAL.GetPlayerById(id);
            return Ok(player);
        }

        // POST api/<PlayerController>
        [HttpPost]
        public IActionResult CreatePlayer([FromBody] Player player)
        {
            var newPlayerId = _playerDAL.CreatePlayer(player);
            _logger.Log(LogLevel.Information, message: "Created player with new PlayerId: {0}", newPlayerId);
            return Ok(newPlayerId);
        }

        // PUT api/<PlayerController>/5
        [HttpPut("{id}")]
        public void UpdatePlayer(int id, [FromBody] Player player)
        {
            _playerDAL.UpdatePlayer(id, player);
        }
    }
}
