using DomainLayer.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Entities.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
			builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.StatusToken)
                .IsRequired();

            builder.HasMany(s => s.Employees)
                .WithOne(e => e.Status)
                .HasForeignKey(e => e.StatusId);

			builder.ToTable("Status");
		}
    }
}
