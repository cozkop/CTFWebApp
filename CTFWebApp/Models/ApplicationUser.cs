using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CTFWebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        public Team MyTeam { get; set; }
        
        public bool captain { get; set; }

    }
}
