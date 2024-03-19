using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager.Data
{
    public class Season_Schedule
    {
        [Key]
        public string RaceName { get; set; }

        public string Season { get; set; }

        public string CircuitName { get; set; }

        public string FirstPracticeDate { get; set; }

        public string SecondPracticeDate { get; set; }

        public string ThirdPracticeDate { get; set; }

        public string QualifyingDate { get; set; }

        public string RaceDate { get; set; }
    }
}
