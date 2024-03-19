using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager.Models.Drivers
{
    public class DriverListAll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public string Role { get; set; } = string.Empty;
        public int SeasonPoints { get; set; }
        public int? CarId { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CarSelection { get; set; }
    }
}
