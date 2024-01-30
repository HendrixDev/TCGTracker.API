using Microsoft.AspNetCore.Mvc;
using TCGTracker.API.DAL.Interface;
using TCGTracker.API.Entities.Models;

namespace TCGTracker.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        //fields
        private readonly ILogger<DeckController> _logger;
        private readonly IDeckDAL _deckDAL;

        //constructor
        public DeckController(ILogger<DeckController> logger, IDeckDAL deckDAL)
        {
            _logger = logger;
            _deckDAL = deckDAL;
        }
        // GET: api/<DeckController>
        [HttpGet("player/{playerId}")]
        public async Task<IActionResult> GetAllDecksByPlayerId(int playerId)
        {
            _logger.Log(LogLevel.Information, message: "Getting all Decks for Player with PlayerID: {0}", playerId);
            var Decks = await _deckDAL.GetAllDecksByPlayerId(playerId);
            return Ok(Decks);
        }

        // GET api/<DeckController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeckById(int id)
        {
            _logger.Log(LogLevel.Information, message: "Getting Deck with ID: {0}", id);
            var Deck = await _deckDAL.GetDeckById(id);
            return Ok(Deck);
        }

        // POST api/<DeckController>
        [HttpPost]
        public IActionResult CreateDeck([FromBody] Deck deck)
        {
            var rowsAffected = _deckDAL.CreateDeck(deck);
            _logger.Log(LogLevel.Information, message: "Deck created successfully, rows affected: {0}", rowsAffected.Result);
            return Ok(rowsAffected.Result);
        }

        // PUT api/<DeckController>/5
        [HttpPut("{id}")]
        public void UpdateDeck(int id, [FromBody] DeckUpdate updatedDeck)
        {
            _deckDAL.UpdateDeck(id, updatedDeck);
        }

        [HttpDelete("{id}")]
        public void DeleteDeck(int id)
        {
            _deckDAL.DeleteDeck(id);
        }
    }
}
