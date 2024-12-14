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
        public IActionResult Register([FromBody] User RegisterUser)
        {
            foreach (var existingUser in User.UsersList)
            {
                if (existingUser.Email == user.Email)
                {
                    return BadRequest(new { message = "This Email is connected to existing User" });

                }
            }
            User.UsersList.Add(user);
            return Ok(new { message = "User registed successfully!" });
        }

          [HttpPost("LogInUser")]
        public IActionResult Login([FromBody] User LogInUser)
        {
            if (LogInUser == null || string.IsNullOrEmpty(LogInUser.Email) || string.IsNullOrEmpty(LogInUser.Password))
            {
                return BadRequest(new { message = "Cant be empty" });
            }

            foreach (var user in User.UsersList)
            {
                if (user.Email == LogInUser.Email && user.Password == LogInUser.Password)
                {
                    return Ok(new { message = "LogUn successful" });
                }
            }

            return Unauthorized(new { message = "Invalid email or password" });
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
