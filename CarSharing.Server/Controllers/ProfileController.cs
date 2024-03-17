using CarSharing.Models.UserModels;
using CarSharing.Server.Models.AuthorizationModels;
using CarSharing.Server.Models.UserModels;
using CarSharing.Server.Repository;
using CarSharing.Server.Servisec;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarSharing.Server.Controllers
{

    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {

        private readonly ApplicationContext _context;

        public ProfileController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet ("get")]
        public async Task<ActionResult<UserEntity>> GetUserProfile(UserService userService)
        {
            string email = "";
            if (Request.Cookies["email"] != null)
            {
               
            }
            email = Request.Cookies["email"].ToString();

            return await userService.GetUserProfile(email);
        }

        // GET api/<ProfileController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProfileController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProfileRequist requist  , UserService service)
        {
           var result = await   service.Update(requist);
          if (result == null)
            {
             return BadRequest();
           }
            return Ok("Account activation was successful");
        }

        // PUT api/<ProfileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProfileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
