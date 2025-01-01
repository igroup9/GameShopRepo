using System.Security.Cryptography.X509Certificates;
using Hw_1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hw_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        // GET: api/<GamesController>
        //return all games from DB
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            Game game = new Game();
            return game.read();
        }


        // GET api/<GamesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("GetByPrice")]
        public IEnumerable<Game> GetByPrice(int minPrice)
        {
            Game game = new Game();
            return game.GamesAbovePrice(minPrice);
        }


        [HttpGet("GetByRankScore/scoreRank{scoreRank}")]
        public IEnumerable<Game> GetByRankScore(int scoreRank)
        {
            Game game = new Game();
            return game.GamesAboveRankScore(scoreRank);
        }


        // POST api/<GamesController>
        [HttpPost]
        public bool POST([FromBody] Game game)

        {
            return game.insert();
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("deleteByid/AppId/{AppId}")]
        public bool Delete(int AppId)
        {
            Game game = new Game();
            return game.DeleteById(AppId);
        }

     



    }
}
