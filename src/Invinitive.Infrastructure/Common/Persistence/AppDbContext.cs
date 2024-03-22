using Invinitive.Domain.Managers;
using Invinitive.Domain.Portfolios;
using Invinitive.Domain.Users;

using Microsoft.EntityFrameworkCore;

namespace Invinitive.Infrastructure.Common;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Manager> Managers { get; set; } = null!;

    public DbSet<Portfolio> Portfolios { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}