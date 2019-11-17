using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTFWebApp.Models
{
    public class TeamCompletedProblem
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public Problem Problem { get; set; }
        public int ProblemId { get; set; }
    }
}
