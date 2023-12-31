﻿using Microsoft.EntityFrameworkCore;
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
		}
	}
}
