using F1_Manager.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HAAS_F1_Manager_Sim.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Season_Schedule> SeasonSchedule { get; set; }
        public DbSet<DriverCar> DriverCar { get; set; }
        public DbSet<CrewMember> Crew { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Car>().HasData(
                    new Car()
                    {
                        CarId = 1,
                        CarName = "VF-21 ",
                        Acceleration = 2.21,
                        Engine = "Ferrari 065",
                        TopSpeed = 210,
                        Weight = 1645,
                    },
                    new Car()
                    {
                        CarId = 2,
                        CarName = "VF-20",
                        Acceleration = 2.35,
                        Engine = "Ferrari 065",
                        TopSpeed = 208,
                        Weight = 1645,
                    });
        }
    }
}
