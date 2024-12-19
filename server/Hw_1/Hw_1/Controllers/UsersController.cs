using Hw_1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hw_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            User user = new User();
            return user.read();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public bool Post([FromBody] User user)
        {
            return user.insert();
        }

         [HttpPost("RegisterUser")]
        public bool Register([FromBody] User RegisterUser)
        {   
            return RegisterUser.insert();
        }

          [HttpPost("LogInUser")]
        public bool Login([FromBody] User LogInUser)
        {
            if (LogInUser == null || string.IsNullOrEmpty(LogInUser.Email) || string.IsNullOrEmpty(LogInUser.Password))
            {
                return false;
            }
            List<User> UsersList = LogInUser.read();


            foreach (var user in UsersList)
            {
                if (user.Email == LogInUser.Email && user.Password == LogInUser.Password)
                {
                    return true;
                }
            }

            return false;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            User user= new User();
            user.Delete(id);
        }
    }
}
