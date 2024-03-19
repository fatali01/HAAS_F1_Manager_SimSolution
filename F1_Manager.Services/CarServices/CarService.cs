using F1_Manager.Data;
using F1_Manager.Models.Cars;
using HAAS_F1_Manager_Sim.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager.Services.CarServices
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;

        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CarCreateAsync(CarCreate model)
        {
            Car car = new Car()
            {
                CarName = model.CarName,
                Engine = model.Engine,
                HorsePower = model.HorsePower,
                Acceleration = model.Acceleration,
                TopSpeed = model.TopSpeed,
                Weight = model.Weight
                
            };
            if(car != null) 
            {
                await _context.Cars.AddAsync(car);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> CarDeleteAsync(int id)
        {
            var toDelete = await _context.Cars.FindAsync(id);
            if (toDelete != null)
            {
                _context.Cars.Remove(toDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<CarListAll>> CarDetailAllAsync()
        {
            return await _context.Cars
                .Include(n => n.Driver)
                .Select(n => new CarListAll()
                {
                    CarId = n.CarId,
                    CarName = n.CarName,
                    Engine = n.Engine,
                    HorsePower = n.HorsePower,
                    Acceleration = n.Acceleration,
                    TopSpeed = n.TopSpeed,
                    Weight = n.Weight
                }).ToListAsync();

        }

        public async Task<CarDetail> CarDetailAsync(int id)
        {
            var carToDetail = await _context.Cars.FindAsync(id);
            if (carToDetail != null)
            {
                CarDetail carDetailed = new CarDetail()
                {
                    CarId = carToDetail.CarId,
                    CarName = carToDetail.CarName,
                    Engine = carToDetail.Engine,
                    TopSpeed = carToDetail.TopSpeed,
                    HorsePower = carToDetail.HorsePower,
                    Acceleration = carToDetail.Acceleration,
                    Weight = carToDetail.Weight
                };
                return carDetailed;
            }
            return null!;
        }

        public async Task<bool> CarUpdateAsync(int id, CarEdit model)
        {
            var carToEdit = await _context.Cars.FindAsync(id);
            if (carToEdit != null)
            {
                carToEdit.CarName = model.CarName;
                carToEdit.Engine = model.Engine;
                carToEdit.HorsePower = model.HorsePower;
                carToEdit.TopSpeed = model.TopSpeed;
                carToEdit.Acceleration = model.Acceleration;
                carToEdit.Weight = model.Weight;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
