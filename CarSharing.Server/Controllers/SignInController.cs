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

namespace CarSharing.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly ILogger <SignInController> _logger;
        public SignInController(ApplicationContext context, ILogger<SignInController> logger)
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
            User user = new User
            {
                Id = Guid.NewGuid(),
                Password = registration.Password,
                Name = registration.Name,
                Email = registration.Email,
                ActivatedAccount = false,
                RoleId = 1
            };
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
