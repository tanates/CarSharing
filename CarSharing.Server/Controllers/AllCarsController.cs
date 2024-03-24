using CarSharing.Models.CarModels;
using CarSharing.Server.Models.RequistModels;
using CarSharing.Server.Repository;
using CarSharing.Server.Servisec;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarSharing.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AllCarsController : ControllerBase
    {


        [HttpGet]
        public async Task<List<CarModelEntity>> GetAllCars (CartCarsService carsService)
        {
            return  await carsService.GetCartCars();
        }

        [HttpGet("{brand}")]
        public async Task<ActionResult> SerchCars([FromBody]string brand, CartCarsService carsService)
        {
            
            var carSerch = await carsService.GetSerchCarBrand(brand);
            if (carSerch== null)
            { 
                var responseMessang = new { messang = "No cars this brands"};
                return Conflict(responseMessang);
            }
            return Ok(carSerch);

        }
       // [Authorize ("Admin")]
        [HttpPost]
        public async Task<ActionResult> AddCart(CartCarsRequistModel requistModel , CartCarsService service)
        {
            var requistModelCart = requistModel == null ? throw new Exception("Поля путсые") : requistModel;

            await service.AddCartCar(requistModelCart); 
            return Ok();
        }

    }
}
