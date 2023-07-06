using DomainLayer.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainLayer.Entities.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            builder.Property(x => x.Post)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(x => x.Birthday)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            builder.Property(x => x.Number)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            builder.HasOne(e => e.Status)
                .WithMany(s => s.Employees)
                .HasForeignKey(e => e.StatusId);

            builder.HasMany(e => e.Projects)
                .WithMany(p => p.Employees);
        }
    }
}
