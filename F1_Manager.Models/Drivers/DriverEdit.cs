using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager.Models.Drivers
{
    public class DriverEdit
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int SeasonPoints { get; set; }
        public int? CarId { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CarSelection { get; set; }
    }
}
