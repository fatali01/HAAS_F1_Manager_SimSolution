using F1_Manager.Models.Cars;
using F1_Manager.Models.DriversCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager.Services.DriverCarServices
{
    internal interface IDriverCarService
    {
        Task<DriverCarsDetail> ListJoinedTableAsync();
    }
}
