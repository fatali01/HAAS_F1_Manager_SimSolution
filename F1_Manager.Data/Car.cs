using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager.Data
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required] 
        public string CarName{ get; set; }
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
        public int? DriverId { get; set; }
        [ForeignKey(nameof(DriverId))]
        public Driver? Driver { get; set; }
    }
}
