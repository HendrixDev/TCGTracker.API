using Microsoft.AspNetCore.Http;
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
        [HttpGet("{id}")]
        public IActionResult GetAllDecksByPlayerId(int playerId)
        {
            _logger.Log(LogLevel.Information, message: "Getting all Decks");
            var Decks = _deckDAL.GetAllDecksByPlayerId(playerId);
            return Ok(Decks);
        }

        // GET api/<DeckController>/5
        [HttpGet("{id}")]
        public IActionResult GetDeckById(int id)
        {
            _logger.Log(LogLevel.Information, message: "Getting Deck with ID: {0}", id);
            var Deck = _deckDAL.GetDeckById(id);
            return Ok(Deck);
        }

        // POST api/<DeckController>
        [HttpPost("{id}")]
        public IActionResult CreateDeck(int playerId, [FromBody] Deck deck)
        {
            var newDeckId = _deckDAL.CreateDeck(playerId, deck);
            _logger.Log(LogLevel.Information, message: "Created Deck with new DeckId: {0}", newDeckId);
            return Ok(newDeckId);
        }

        // PUT api/<DeckController>/5
        [HttpPut("{id}")]
        public void UpdateDeck(int id, [FromBody] Deck deck)
        {
            _deckDAL.UpdateDeck(id, deck);
        }

    }
}
