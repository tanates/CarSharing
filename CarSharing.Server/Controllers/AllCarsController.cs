using CarSharing.Models.CarModels;
using CarSharing.Server.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarSharing.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AllCarsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AllCarsController(ApplicationContext context)
        {
            _context=context;
        }


        public async Task<CarModelEntity> GetAllCar ()
        {

        }
    }
}
