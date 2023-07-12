using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static DomainLayer.Enums.StatusToken;

namespace DomainLayer.Entities.Models
{
    public class CompanyStructureContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public CompanyStructureContext(DbContextOptions<CompanyStructureContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Status>().HasData(
				new Status() { Id = 1, Name = Active},
                new Status() { Id = 2, Name = OnHoliday },
                new Status() { Id = 3, Name = Dismissed },
                new Status() { Id = 4, Name = Hospital },
                new Status() { Id = 5, Name = InDecree }
                );
		}
	}
}
