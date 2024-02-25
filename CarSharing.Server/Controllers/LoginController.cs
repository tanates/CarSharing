using CarSharing.Models.AuthorizationModels;
using CarSharing.Models.Repository;
using CarSharing.Models.UserModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarSharing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public LoginController(ApplicationContext context)
        {
           _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user =  await _context.Login.FirstOrDefaultAsync(i=>i.UserName == model.UserName && i.Password==model.Password 
            ||i.Email == model.Email &&i.Password == model.Password);
            if (user != null)
            {
                // Пользователь с указанным логином не найден
                return Ok(new { redirectTo = "/home" });
            }
             else
               return BadRequest(new { message = "Invalid username or password" });
        }
    }
}
