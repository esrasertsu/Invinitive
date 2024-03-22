using Invinitive.Domain.Portfolios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invinitive.Infrastructure.Portfolios.Persistence;

public class PortfolioConfigurations : IEntityTypeConfiguration<Portfolio>
{
    public void Configure(EntityTypeBuilder<Portfolio> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
             .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .IsRequired(); // Assuming Name is required

        // Configure ManagerId as a foreign key to the Manager entity
        builder.HasOne(p => p.Manager)
            .WithMany()
            .HasForeignKey(p => p.ManagerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
    }
}

