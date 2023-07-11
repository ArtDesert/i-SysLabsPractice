using DomainLayer.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Entities.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(x => x.ProjectCode)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.HasMany(p => p.Employees)
                .WithMany(e => e.Projects);

			builder.ToTable("Project");
		}
    }
}
