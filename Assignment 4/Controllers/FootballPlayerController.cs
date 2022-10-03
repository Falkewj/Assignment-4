using Assignment_1;
using Assignment_4.Managers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayerController : ControllerBase
    {
        private readonly FootballPlayersManager manager = new FootballPlayersManager();
        // GET: api/<FootballPlayerController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<FootballPlayer>> GetAll()
        {
            return Ok(manager.GetAll());
        }

        // GET api/<FootballPlayerController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<FootballPlayer> GetById(int id)
        {
            FootballPlayer result = manager.GetById(id);
            if (result == null) return NotFound("Could not find any player with matching ID");
            return Ok(result);
        }

        // POST api/<FootballPlayerController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer footballPlayer)
        {
            manager.Add(footballPlayer);
            return Created($"API/FootballPlayer/{footballPlayer.Id}", footballPlayer);
        }

        // PUT api/<FootballPlayerController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer footballPlayer)
        {
            FootballPlayer result = manager.Update(id, footballPlayer);
            if (result == null) return NotFound("Could not find a player with matching ID");
            return Ok(result);
        }

        // DELETE api/<FootballPlayerController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            FootballPlayer result = manager.Delete(id);
            if (result == null) return NotFound("Could not find a player with a matching ID");
            return Ok(result);
        }
    }
}
