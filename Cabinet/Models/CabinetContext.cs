using Cabinet.Models.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cabinet.Models;

public class CabinetContext : IdentityDbContext<CabinetUser>
{
    public CabinetContext(DbContextOptions<CabinetContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // To seed the database roles
        modelBuilder.ApplyConfiguration(new RoleConfiguration());

        modelBuilder.Entity<Commute>()
            .HasOne(c => c.Origin)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Commute>()
            .HasOne(c => c.Destination)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }

    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Commute> Commutes { get; set; } = null!;
    public DbSet<Neighborhood> Neighborhoods { get; set; } = null!;
}