using F1_Manager.Data;
using F1_Manager.Models.Cars;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager.Models.Drivers
{
    public class DriverDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public int SeasonPoints { get; set; } = 0;
        public int? CarId { get; set; }
        //[ValidateNever]
        //public IEnumerable<SelectListItem> CarSelection { get; set; }
        public CarListAll Car { get; set; }
    }
}
