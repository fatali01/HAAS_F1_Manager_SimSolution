using F1_Manager.Data;
using F1_Manager.Models.CrewMembers;
using F1_Manager.Services.CrewMembers;
using Microsoft.AspNetCore.Mvc;

namespace HAAS_F1_Manager_Sim.Controllers
{
    public class CrewMemberController : Controller
    {
        private readonly ICrewService _crewService;

        public CrewMemberController(ICrewService crewService)
        {
            _crewService = crewService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var workers = await _crewService.CrewDetailAllAsync();
            return View(workers);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var worker = await _crewService.CrewDetailAsync(id);
            return View(worker);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var crew = await _crewService.CrewDetailAsync(id);
            if (crew == null)
            {
                return NotFound();
            }
            CrewEdit crewEdit = new CrewEdit()
            {
                Id = crew.Id,
                Name = crew.Name,
                Age = crew.Age,
                PhoneNumber = crew.PhoneNumber,
                Role = crew.Role,
                RoleDescription = crew.RoleDescription,
                Salary = crew.Salary,
            };
            return View(crewEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CrewEdit model)
        {
            if (ModelState.IsValid)
            {
                if(await _crewService.CrewUpdateAsync(id, model))
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new CrewCreate());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CrewCreate model)
        {
            if (ModelState.IsValid)
            {
                if(await _crewService.CrewCreateAsync(model))
                    return RedirectToAction(nameof(Index));
                return NotFound();
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var crewToDelete = await _crewService.CrewDetailAsync(id);
            if(crewToDelete == null)
            {
                return NotFound();
            }
            CrewEdit crewEdit = new CrewEdit()
            {
                Id = crewToDelete.Id,
                Name = crewToDelete.Name,
                Age = crewToDelete.Age,
                Role = crewToDelete.Role,
                RoleDescription = crewToDelete.RoleDescription,
                PhoneNumber = crewToDelete.PhoneNumber,
                Salary = crewToDelete.Salary,
            };
            return View(crewToDelete);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCrew(int id)
        {
            if(await _crewService.CrewDeleteAsync(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
