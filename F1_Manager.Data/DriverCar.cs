using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager.Data
{
    public class DriverCar
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        [ForeignKey(nameof(CarID))]
        public Car Car { get; set; }
        public int DriverId { get; set; }
        [ForeignKey(nameof(DriverId))]
        public Driver Driver { get; set; }
    }
}
