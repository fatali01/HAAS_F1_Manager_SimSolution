using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager.Models.CrewMembers
{
    public class CrewEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public string RoleDescription { get; set; }
        public double Salary { get; set; }
        public string PhoneNumber { get; set; }
    }
}
