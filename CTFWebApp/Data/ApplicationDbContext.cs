using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CTFWebApp.Models;

namespace CTFWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Problem> Problem { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamCompletedProblem> TeamCompletedProblem { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //composite primary keys for many to many relationships
            builder.Entity<TeamCompletedProblem>()
                    .HasKey(k => new { k.TeamId, k.ProblemId });

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
