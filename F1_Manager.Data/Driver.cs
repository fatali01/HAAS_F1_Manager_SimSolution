using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager.Data
{
    public class Driver
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int SeasonPoints { get; set; }
        [Required]
        public string? Role { get; set; }
        public int? CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car? Cars { get; set; }
    }
}
