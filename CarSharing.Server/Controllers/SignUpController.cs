using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarSharing.Models.AuthorizationModels;
using CarSharing.Models.Repository;
using CarSharing.Models.UserModels;
using System.Net;

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
        public async Task<ActionResult<Registration>> PostRegistration(Registration registration)
        {
            _logger.LogInformation("Executing PostRegistration");
            User user = new User();
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            if (_context.Users.Any(i => i.Email == registration.Email))
            {
                if (_context.Users.Any(i => i.Name == registration.Name))
                {
                    var error = new { message = "This name and email  is occupied . Choose another one , or sign in" };
                    return Conflict(error);

                }
                var errorResponse = new { message = "This user is already registered" };
                return Conflict(errorResponse);
            }

            if (_context.Users.Any(i => i.Name == registration.Name))
            {
                var errorResponse = new { message = "This name  is occupied . Choose another one" };
                return Conflict(errorResponse);
            }
              
           
            user = new User
            {
                Id = Guid.NewGuid(),
                Password = registration.Password,
                Name = registration.Name,
                Email = registration.Email,
                ActivatedAccount = false,
                RoleId = 1
            };

            Login login = new Login
            {
                UserName = registration.Name,
                Password = registration.Password,
                Email = registration.Email,
            };
            _context.Login.Add(login);
            _context.Users.Add(user);
            _context.Registration.Add(registration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistration", new { id = registration.Id }, registration);
        }

    

        private bool RegistrationExists(Guid id)
        {
            return _context.Registration.Any(e => e.Id == id);
        }
    }
}
