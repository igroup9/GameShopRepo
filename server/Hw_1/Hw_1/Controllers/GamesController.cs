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



        [HttpPost("GetByPrice")]
        public IEnumerable<Game> GetByPrice([FromBody] GameRequest gameRequest)
        {
            Game game = new Game();
            return game.GamesAbovePrice(gameRequest);
        }


        [HttpPost("GetByRankScore")]
        public IEnumerable<Game> GetByRankScore([FromBody] GameRequest gameRequest)
        {
            Game game = new Game();
            return game.GamesAboveRankScore(gameRequest);
        }


        // POST api/<GamesController>
        [HttpPost]
        public bool POST([FromBody] GameRequest gameRequest)

        {
            Game game = new Game();

            return game.insert(gameRequest.Appid,gameRequest.Id);
        }

        // POST api/<GamesController>/5
        [HttpPost("id")]
        public IEnumerable<Game> GetMyGames([FromBody] int id)
        {
            Game game = new Game();
            return game.readMyList(id);

        }

        [HttpPost("ReturnUnpurchasedGames")]
        public IEnumerable<Game> ReturnUnpurchasedGames([FromBody] int id)
        {
            Game game = new Game();

            if (id == 0)
                return game.read();
            else
                return game.readMyUnpurchasedGames(id);

        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("deleteByid/GameRequest")]
        public bool Delete([FromBody] GameRequest gameRequest)
        {
            Game game = new Game();
            return game.DeleteById(gameRequest);
        }

     



    }
}
