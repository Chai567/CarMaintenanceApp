using Microsoft.EntityFrameworkCore;

namespace CarMaintenanceApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions
       <ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Car> Car { get; set; }
        public DbSet<CarMaintenanceStatus> CarMaintenanceStatus { get; set; }
        public DbSet<CarService> CarService { get; set; }
    }
}
