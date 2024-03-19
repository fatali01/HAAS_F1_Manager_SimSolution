using F1_Manager.Models.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager.Services.DriverServices
{
    public interface IDriverService
    {
        Task<bool> DriverCreateAsync(DriverCreate model);
        Task<DriverDetail> DriverDetailAsync(int id);
        Task<List<DriverListAll>> DriverDetailAllAsync();
        Task<bool> DriverUpdateAsync(int id, DriverEdit model);
        Task<bool> DriverDeleteAsync(int id);
        Task<bool> AddCarToDriverAsync(int driverId, int carId);
        Task<bool> DeleteCarFromDriverAsync(int id);
    }
}
