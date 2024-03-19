using F1_Manager.Models.Cars;
using F1_Manager.Services.CarServices;
using Microsoft.AspNetCore.Mvc;

namespace HAAS_F1_Manager_Sim.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cars = await _carService.CarDetailAllAsync();
            return View(cars);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var car = await _carService.CarDetailAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carService.CarDetailAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            CarEdit carEdit = new CarEdit()
            {
                CarId = car.CarId,
                CarName = car.CarName,
                Engine = car.Engine,
                TopSpeed = car.TopSpeed,
                Acceleration = car.Acceleration,
                HorsePower = car.HorsePower,
                Weight = car.Weight,
            };
            return View(carEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarEdit model)
        {
            if(ModelState.IsValid)
            {
                if(await _carService.CarUpdateAsync(id, model))
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound(model.CarId);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new CarCreate());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarCreate model)
        {
            if (ModelState.IsValid)
            {
                if(await _carService.CarCreateAsync(model))
                    return RedirectToAction(nameof(Index));
                return NotFound();
            }
            return View(model); 
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if (await _carService.CarDeleteAsync(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
           
        }


    }
}
