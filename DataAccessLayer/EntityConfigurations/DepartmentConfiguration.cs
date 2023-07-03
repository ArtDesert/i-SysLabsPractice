using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccessLayer.EntityConfigurations
{
	internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.IsRequired();

			builder.Property(x => x.Name)
				.HasMaxLength(50)
				.IsUnicode()
				.IsRequired();

			builder.Property(x => x.DepartmentCode)
				.HasMaxLength(50)
				.IsUnicode()
				.IsRequired();

			builder.HasMany(d => d.Employees)
				.WithOne(e => e.Department)
				.HasForeignKey(e => e.DepartmentId);
		}
	}
}
