using Microsoft.AspNetCore.Mvc;
using TCGTracker.API.DAL;
using TCGTracker.API.DAL.Interface;
using TCGTracker.API.Entities.Models;

namespace TCGTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        //fields
        private readonly ILogger<MatchesController> _logger;
        private readonly IMatchDAL _matchDAL;

        //constructor
        public MatchesController(ILogger<MatchesController> logger, IMatchDAL matchDAL)
        {
            _logger = logger;
            _matchDAL = matchDAL;

        }

        // GET: api/<MatchController>
        [HttpGet("{playerId}")]
        public IActionResult GetAllMatchesByPlayerId(int playerId)
        {
            //TODO: make this endpoint work
            //need to add PlayerOneID and PlayerTwoID to DB and possibly have them replace PlayerOne and PlayerTwo
            _logger.Log(LogLevel.Information, message: "Getting all Matches for player with Id: {0}", playerId);
            var matches = _matchDAL.GetAllMatchesByPlayerId(playerId);
            return Ok(matches);
        }

        // GET api/<MatchController>/5
        [HttpGet("{id}")]
        public IActionResult GetMatchById(int id)
        {
            //Do I even need this endpoint? What is the purpose of just grabbing a single match?
            //Maybe to display an edit screen, but you could just grab a certain match using the endpoint above.
            _logger.Log(LogLevel.Information, message: "Getting Match with ID: {0}", id);
            var match = _matchDAL.GetMatchById(id);
            return Ok(match);
        }

        // POST api/<MatchController>
        [HttpPost]
        public async Task<IActionResult> CreateMatch([FromBody] Match match)
        {
            var newMatchId = await _matchDAL.CreateMatch(match);
            _logger.Log(LogLevel.Information, message: "Created Match with new MatchId: {0}", newMatchId);
            return Ok(newMatchId);
        }

        // PUT api/<MatchController>/5
        [HttpPut("{id}")]
        public void UpdateMatch(int id, [FromBody] Match match)
        {
            _matchDAL.UpdateMatch(id, match);
        }

        [HttpDelete("{id}")]
        public void DeleteMatch(int id)
        {
            _matchDAL.DeleteMatch(id);
        }
    }
}
