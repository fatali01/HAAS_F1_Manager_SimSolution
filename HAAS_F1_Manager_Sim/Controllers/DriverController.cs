using F1_Manager.Models.Drivers;
using F1_Manager.Services.CarServices;
using F1_Manager.Services.DriverServices;
using HAAS_F1_Manager_Sim.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HAAS_F1_Manager_Sim.Controllers
{
    public class DriverController : Controller
    {
        private readonly IDriverService _driverService;
        private readonly ICarService _carService;

        public DriverController(IDriverService driverService, ICarService carService)
        {
            _driverService = driverService;
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var drivers = await _driverService.DriverDetailAllAsync();
            return View(drivers);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var driver = await _driverService.DriverDetailAsync(id);
            if (driver == null) return BadRequest();
            return View(driver);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var driver = await _driverService.DriverDetailAsync(id);
            if (driver == null) return NotFound();
            var driverEdit = new DriverEdit()
            {
                Id = driver.Id,
                Name = driver.Name,
                Age = driver.Age,
                Height = driver.Height,
                SeasonPoints = driver.SeasonPoints, 
            };
            return View(driverEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DriverEdit model)
        {
            if (ModelState.IsValid)
                if (await _driverService.DriverUpdateAsync(id, model))
                    return (RedirectToAction(nameof(Index)));
                else 
                    return NotFound();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new DriverCreate());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DriverCreate model)
        {
            if (ModelState.IsValid)
            {
                if (await _driverService.DriverCreateAsync(model))
                    return (RedirectToAction(nameof(Index)));
                else
                    return NotFound();
                
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var driver = await _driverService.DriverDetailAsync(id);
            if (driver == null) return NotFound();
            return View(driver);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            if (await _driverService.DriverDeleteAsync(id))
                return (RedirectToAction(nameof(Index)));
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> AddCarToDriver(int id)
        {
            var driverInfo = await _driverService.DriverDetailAsync(id);
            var driverUpsertData = new DriverEdit() 
            {
                Name = driverInfo.Name,
                Age = driverInfo.Age,
                Height = driverInfo.Height,
                SeasonPoints = driverInfo.SeasonPoints
            };
            var carSelectionList = _carService.CarDetailAllAsync().Result.Select(c => new SelectListItem()
            {
                Text = c.CarName,
                Value = c.CarId.ToString()
            }).ToList();
            driverUpsertData.CarSelection = carSelectionList;
            return View(driverUpsertData);
        }
        [HttpPost]
        public async Task<IActionResult> AddCarToDriverAsync(int driverId, int carId)
        {
            var add = await _driverService.AddCarToDriverAsync(driverId, carId);
            if (add)
            {
                // If successful, redirect to a success page or perform any other action
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // If not successful, return a not found error or handle the failure appropriately
                return NotFound();
            }
        }
        [HttpGet]
        public async Task<IActionResult> RemoveCarFromDriver(int id)
        {
            var driver = await _driverService.DriverDetailAsync(id);
            return View(driver);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveCarFromDriverasync(int id)
        {
            var driver = await _driverService.DeleteCarFromDriverAsync(id);
            if (driver)
            {
                // If successful, redirect to a success page or perform any other action
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // If not successful, return a not found error or handle the failure appropriately
                return NotFound();
            }

        }
    }
}
