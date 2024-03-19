using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager.Models.Cars
{
    public class CarCreate
    {
        [Required]
        public string CarName { get; set; }
        [Required]
        public string Engine { get; set; }
        [Required]
        public int HorsePower { get; set; }
        [Required]
        public double Acceleration { get; set; }
        [Required]
        public double TopSpeed { get; set; }
        [Required]
        public double Weight { get; set; }
    }
}
