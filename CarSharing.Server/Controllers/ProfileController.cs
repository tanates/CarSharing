using CarSharing.Models.Rental;
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

        [HttpGet ("get")]
        
        public async Task<ActionResult> GetUserProfile(UserService userService , RentalServisec rentalServisec )
        {
            string email = "";
            if (Request.Cookies["email"] != null)
            {
                email = Request.Cookies["email"].ToString();
            }
            else
            {
                // Верните ошибку, если куки email не существует
                return BadRequest("Email cookie not found");
            }

            var rentalHistory = await rentalServisec.GetHistoryRental(email);
            var userProfile =  await userService.GetUserProfile(email);

            return Ok(new Dictionary<string, object>
            {
                { "UserEntity", userProfile },
                { "RentalHistoryEntity", rentalHistory }
            });

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

            string email = "";
            if (Request.Cookies["email"] != null)
            {
                email = Request.Cookies["email"].ToString();
            }
            else
            {
                // Верните ошибку, если куки email не существует
                return BadRequest("Email cookie not found");
            }
            requist.Email = email;
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
