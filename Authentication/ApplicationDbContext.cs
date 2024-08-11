using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _34221700_Project2_CMPG323.Models;

namespace _34221700_Project2_CMPG323.Authentication
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<JobTelemetry> JobTelemetries { get; set; }
        // Other DbSet properties
    }
}
