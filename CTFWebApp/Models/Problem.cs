using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CTFWebApp.Models
{
    public class Problem
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string ProblemName { get; set; }

        [Display(Name = "Problem Description")]
        public string ProblemDescription { get; set; }

        [Display(Name = "Difficulty")]
        public string ProblemLevel { get; set; }

        public int Points { get; set; }

        public string Answer { get; set; }
        
    }
}
