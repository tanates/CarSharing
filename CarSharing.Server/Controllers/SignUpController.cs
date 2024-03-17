using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarSharing.Models.AuthorizationModels;
using CarSharing.Models.UserModels;
using System.Net;
using System.Security.Cryptography;
using Microsoft.CodeAnalysis.Scripting;
using CarSharing.Server.Repository;
using CarSharing.Server.Servisec;

namespace CarSharing.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly ILogger <SignUpController> _logger;
        public SignUpController(ApplicationContext context, ILogger<SignUpController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/SignIn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistration()
        {
            return await _context.Registration.ToListAsync();
        }

  

        // POST: api/SignIn
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IResult> PostRegistration(Registration registration,UserService userService)
        {
            if(_context.Users.Any(c=>c.Email==registration.Email)) 
            {
                return Results.Conflict("User as register");
            }
            
            await userService.Register(registration.Name, registration.Password,registration.Email);
            return Results.Ok();
        }

 



        private bool RegistrationExists(Guid id)
        {
            return _context.Registration.Any(e => e.Id == id);
        }
    }
}
