using Invinitive.Domain.Managers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invinitive.Infrastructure.Managers.Persistence;

 public class ManagerConfigurations : IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
             .ValueGeneratedOnAdd();

        builder.Property(m => m.Name)
            .IsRequired();

        builder.HasOne(m => m.ReportsToManager)
            .WithMany()
            .HasForeignKey(m => m.ReportsTo)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
    }
}
