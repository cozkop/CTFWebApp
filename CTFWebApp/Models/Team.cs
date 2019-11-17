using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CTFWebApp.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string TeamName { get; set; }

        [Display(Name = "Team Bio")]
        public string TeamDescription { get; set; }

        public int Score { get; set; }

        public List<TeamCompletedProblem> TeamCompletedProblems { get; set; }
    }
}
