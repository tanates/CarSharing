using CarSharing.Models.AuthorizationModels;
using CarSharing.Models.UserModels;
using CarSharing.Server.Repository;
using CarSharing.Server.Servisec;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;
using System.Security.Cryptography;

namespace CarSharing.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IHttpContextAccessor _httpContext;
        public LoginController(ApplicationContext context , IHttpContextAccessor httpContext)
        {
           _context = context;
            _httpContext    = httpContext;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] Login model , UserService userService )
        {
            var httpContext = _httpContext.HttpContext;
            var token = await userService.Login(model.Email , model.Password);
         
            httpContext.Response.Cookies.Append("testy-login", token);
            HttpContext.Response.Cookies.Append("email", model.Email );
            return Ok(token);
        }

     
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("CookieAuth");
            return Ok("Вы вышли из системы");
        }
    }
}
