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
        public async Task<IActionResult> GetPlayerById(int id)
        {
            try
            {
                _logger.Log(LogLevel.Information, message: "Getting player with ID: {0}", id);
                var player = await _playerDAL.GetPlayerById(id);
                return Ok(player);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<PlayerController>
        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] Player player)
        {
            try
            {
                var newPlayerId = await _playerDAL.CreatePlayer(player);
                _logger.Log(LogLevel.Information, message: "Created player with new PlayerId: {0}", newPlayerId);
                return Ok(newPlayerId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<PlayerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(int id, [FromBody] Player player)
        {
            try
            {
                var playerUpdated = await _playerDAL.UpdatePlayer(id, player);
                _logger.Log(LogLevel.Information, message: "Updated player with PlayerId: {0}", id);
                return Ok(playerUpdated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
