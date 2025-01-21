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

        //get all users list
        [HttpGet]
        public IEnumerable<User> Get()
        {
            User user = new User();
            return user.read();
        }

        //get all users list for admin
        [HttpGet("ReadAdminUserList")]
        public List<object> ReadAdminUserList()
        {
            User user = new User();
            return user.ReadAdminUserList();
        }

        // GET api/<UsersController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


        //not in use - we have RegisterUser
        // POST api/<UsersController>
        //[HttpPost]
        //public bool Post([FromBody] User user)
        //{
        //    return user.insert();   
        //}




        [HttpPost("RegisterUser")]
        public bool Register([FromBody] User RegisterUser)
        {   
            return RegisterUser.insert();
        }



          [HttpPost("LoginUser")]
        public User Login([FromBody] User LoginUser)
        {
            if (LoginUser == null || string.IsNullOrEmpty(LoginUser.Email) || string.IsNullOrEmpty(LoginUser.Password))
            {
                return null;
            }

            return LoginUser.Login();
        }



        // PUT api/<UsersController>/5
        [HttpPut("UpdateUser")]
        public User Put( [FromBody] User user)
        {
            return user.Upadte();

        }

        // PUT api/<UsersController>/5
        [HttpPut("UpdateUserIsActive/id/{id}/isActive/isActive")]
        public bool UpdateUserIsActive(int id, bool isActive)
        {
            User user= new User();
            return user.UpdateUserIsActive(id,isActive);

        }



        //not in use - dont work with DB
        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            User user= new User();
            user.Delete(id);
        }
    }
}
