using F1_Manager.Data;
using F1_Manager.Models.Drivers;
using HAAS_F1_Manager_Sim.Data;
using Microsoft.EntityFrameworkCore;

namespace F1_Manager.Services.DriverServices
{
    public class DriverService : IDriverService
    {
        private readonly ApplicationDbContext _context;
        public DriverService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DriverCreateAsync(DriverCreate model)
        {
            Driver Driver = new Driver()
            {
                Name = model.Name,
                Height = model.Height,
                Age = model.Age,
                SeasonPoints = model.SeasonPoints,
                Role = model.Role,
                CarId = model.CarId,
            };
            if (Driver != null)
            {
                await _context.Drivers.AddAsync(Driver);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DriverDeleteAsync(int id)
        {
            var toDelete = await _context.Drivers.FindAsync(id);
            if (toDelete != null)
            {
                _context.Drivers.Remove(toDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<DriverListAll>> DriverDetailAllAsync()
        {
            return await _context.Drivers
                .Include(n => n.Cars)
                .Select(n => new DriverListAll()
                {
                    Id = n.ID,
                    Name = n.Name,
                    Height = n.Height,
                    Age = n.Age,
                    SeasonPoints = n.SeasonPoints,
                    CarId = n.CarId,
                }).ToListAsync();
        }

        public async Task<DriverDetail> DriverDetailAsync(int id)
        {
            var driverToDetail = await _context.Drivers.Include(d => d.Cars).FirstOrDefaultAsync(x => x.ID == id);
            if (driverToDetail != null)
            {
                DriverDetail driverDetailed = new DriverDetail()
                {
                    Id = driverToDetail.ID,
                    Name = driverToDetail.Name,
                    Height = driverToDetail.Height,
                    Age = driverToDetail.Age,
                    SeasonPoints = driverToDetail.SeasonPoints,
                };
                var car = _context.Cars.FirstOrDefaultAsync(x => x.CarId == driverDetailed.CarId);
                if (car != null)
                {
                    driverDetailed.Car = new Models.Cars.CarListAll()
                    {
                        CarId = driverToDetail.Cars.CarId,
                        CarName = driverToDetail.Cars.CarName,
                        Acceleration = driverToDetail.Cars.Acceleration,
                        Engine = driverToDetail.Cars.Engine,
                        HorsePower = driverToDetail.Cars.HorsePower,
                        TopSpeed = driverToDetail.Cars.TopSpeed,
                        Weight = driverToDetail.Cars.Weight,
                    };
                }
                return driverDetailed;
            }
            return null!;
        }

        public async Task<bool> DriverUpdateAsync(int id, DriverEdit model)
        {
            var DriverToEdit = await _context.Drivers.SingleOrDefaultAsync(x => x.ID == id);
            if (DriverToEdit != null)
            { var previousCarId = DriverToEdit.CarId;
                DriverToEdit.Name = model.Name;
                DriverToEdit.Height = model.Height;
                DriverToEdit.Age = model.Age;
                DriverToEdit.SeasonPoints = model.SeasonPoints;
                if(model.CarId == null)
                {
                    DriverToEdit.CarId = null;
                    await _context.SaveChangesAsync();
                }
                else if(model.CarId != previousCarId && model.CarId != 0 && model.CarId != null) 
                {
                    DriverToEdit.CarId = null;
                    await _context.SaveChangesAsync();
                    DriverToEdit.CarId = model.CarId.Value;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> AddCarToDriverAsync(int driverId, int carId)
        {
            var driver = await _context.Drivers.FindAsync(driverId);
            if (driver != null)
            {
                driver.CarId = carId;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<bool> DeleteCarFromDriverAsync(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);


            if (driver != null)
            {
                driver.CarId = null;
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;

        }
    }
}
