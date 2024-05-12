using Accessors;
using Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;


namespace Frontend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        
        IUserManager userManager = new UserManager();

        [HttpGet("{username}/{password}")]
        public Int32 Get(string username, string password)
        {

            Int32 result = userManager.logInValidation(username, password);

            return result;


        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public List<string> Get(int id)
        {
            return userManager.accountInfo(id);
        }

        [HttpPost]
        public Int32 Post(User user)
        {
            
            return userManager.registerNewUser(user.Email, user.Name, user.Password);


        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}/{username}/{email}/{password}")]
        public void Put(int id, string username, string email, string password)
        {
            userManager.updateUserAccountInfo(id, username, email, password);

            return;
        }

        
        [HttpPut("{id}/{name}/{phone}")]
        public void Put(int id, string name, string phone)
        {
            userManager.updateUserPersonalInfo(id, name, phone);
            return;
        }
    }
}