using F1_Manager.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace F1_Manager.Services.CarServices
{
    public interface ICarService
    {
        Task<bool> CarCreateAsync(CarCreate model);
        Task<CarDetail> CarDetailAsync(int id);
        Task<List<CarListAll>> CarDetailAllAsync();
        Task<bool> CarUpdateAsync(int id, CarEdit model);
        Task<bool> CarDeleteAsync(int id);
    }
}
