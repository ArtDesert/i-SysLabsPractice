using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccessLayer.Entities
{
	internal class CompanyStructureContext : DbContext
	{
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Projects { get; set; }
        public DbSet<Department> Statuses { get; set; }

        public CompanyStructureContext() : base()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CompanyStructure;Username=postgres;Password=123");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
