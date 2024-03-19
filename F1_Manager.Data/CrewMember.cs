using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager.Data
{
    public class CrewMember
    {
        public CrewMember() { }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string RoleDescription { get; set; }
        [Required]
        public double Salary { get; set; }
        public string PhoneNumber { get; set; }
    }
}
