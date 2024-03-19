using F1_Manager.Data;
using F1_Manager.Models.Cars;
using F1_Manager.Models.Drivers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager.Models.DriversCars
{
    public class DriverCarsDetail
    {
        public DriverListAll Driver { get; set; }

        public CarListAll Car { get; set; }
    }
}
