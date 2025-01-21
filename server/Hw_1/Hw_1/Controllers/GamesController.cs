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

        //get all Games list for admin
        [HttpGet("ReadAdminGameList")]
        public List<object> ReadAdminGameList()
        {
            Game game = new Game();
            return game.ReadAdminGameList();
        }



        [HttpGet("GetByPrice/Id/{Id}/Num/{Num}")]
        public IEnumerable<Game> GetByPrice(int Id, int Num)
        {

            GameRequest gameRequest = new GameRequest();
            gameRequest.Id = Id;
            gameRequest.Num = Num;

            Game game = new Game();
            return game.GamesAbovePrice(gameRequest);
        }


        [HttpGet("GetByRankScore/Id/{Id}/Num/{Num}")]
        public IEnumerable<Game> GetByRankScore(int Id, int Num)
        {
            GameRequest gameRequest = new GameRequest();
            gameRequest.Id = Id;
            gameRequest.Num = Num;

            Game game = new Game();
            return game.GamesAboveRankScore(gameRequest);
        }


        //not in use
        //-------------------------------------------------------------------------------------------------------------------------------

        //POST api/<GamesController>
        [HttpPost]
        public bool POST([FromBody] GameRequest gameRequest)

        {
            Game game = new Game();

            return game.insert(gameRequest.Appid, gameRequest.Id);
        }
        //-------------------------------------------------------------------------------------------------------------------------------


        // POST api/<GamesController>/5
        [HttpGet("GetMyGames/id/{id}")]
        public IEnumerable<Game> GetMyGames( int id)
        {
            Game game = new Game();
            return game.readMyList(id);

        }

        [HttpGet("ReturnUnpurchasedGames/id/{id}")]
        public IEnumerable<Game> ReturnUnpurchasedGames( int id)
        {
            Game game = new Game();

            if (id == 0)
                return game.read();
            else
                return game.readMyUnpurchasedGames(id);

        }



        //not in use 
        //-------------------------------------------------------------------------------------------------------------------------------
        // PUT api/<GamesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
        //-------------------------------------------------------------------------------------------------------------------------------


        // DELETE api/<GamesController>/5
        [HttpDelete("deleteByid/GameRequest")]
        public bool Delete([FromBody] GameRequest gameRequest)
        {
            Game game = new Game();
            return game.DeleteById(gameRequest);
        }

     



    }
}
