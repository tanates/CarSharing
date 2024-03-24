using CarSharing.Server.Models.RequistModels;
using CarSharing.Server.Servisec;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarSharing.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RentalACarController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> GetRenta(RentalServisec servisec, RentaCarRequist requist)
        {
            string email = "";
            if (Request.Cookies["email"] != null)
            {
                email = Request.Cookies["email"].ToString();
            }
           
            var balance = await servisec.SetRental(requist , email);
            return Ok(balance);
        }
     
    }
}
