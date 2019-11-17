using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTFWebApp.Models
{
    public class MyTeamDetailsViewModel
    {
        public Team Team { get; set; }

        public List<ApplicationUser> ApplicationUsers { get; set; }

    }
}
