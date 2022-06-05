using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult GetAllMatches()
        {
            _logger.Log(LogLevel.Information, message: "Getting all Matches");
            var matches = _matchDAL.GetAllMatches();
            return Ok(matches);
        }

        // GET api/<MatchController>/5
        [HttpGet("{id}")]
        public IActionResult GetMatchById(int id)
        {
            _logger.Log(LogLevel.Information, message: "Getting Match with ID: {0}", id);
            var match = _matchDAL.GetMatchById(id);
            return Ok(match);
        }

        // POST api/<MatchController>
        [HttpPost]
        public IActionResult CreateMatch([FromBody] Match match)
        {
            var newMatchId = _matchDAL.CreateMatch(match);
            _logger.Log(LogLevel.Information, message: "Created Match with new MatchId: {0}", newMatchId);
            return Ok(newMatchId);
        }

        // PUT api/<MatchController>/5
        [HttpPut("{id}")]
        public void UpdateMatch(int id, [FromBody] Match match)
        {
            _matchDAL.UpdateMatch(id, match);
        }

    }
}
