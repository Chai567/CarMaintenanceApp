using CarMaintenanceApp.Models;
using CarMaintenanceApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarMaintenanceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarDetailService _carDetailService;

        public CarController(ICarDetailService carDetailService)
        {
            _carDetailService = carDetailService;
        }
        // GET: api/<CarController>
        [HttpGet]
        public async Task<IActionResult> GetAllCarDetails()
        {
            var carDetails = await _carDetailService.GetCarDetails();
            return Ok(carDetails);

        }

        // POST api/<CarController>
        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            else
            {
                var createdCar = await _carDetailService.CreateCar(car);
                return Ok(createdCar);
            }
        }


    }
}
