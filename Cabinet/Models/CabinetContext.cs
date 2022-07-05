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
        modelBuilder.ApplyConfiguration(new NeighborhoodConfiguration());

        // If a address is deleted, the commutes will remain
        modelBuilder.Entity<Commute>()
            .HasOne(commute => commute.Origin)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        // If a address is deleted, the commutes will remain
        modelBuilder.Entity<Commute>()
            .HasOne(commute => commute.Destination)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Commute>()
            .HasOne(commute => commute.Driver)
            .WithMany(driver => driver.DriverCommutes)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Commute>()
            .HasOne(commute => commute.Commuter)
            .WithMany(driver => driver.CommuterCommutes)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Commute>()
            .Property(commute => commute.Status)
            .HasDefaultValue(CommuteStatus.WaitingForDriver);

        modelBuilder.Entity<Commute>()
            .Property(commute => commute.DateRequested)
            .HasDefaultValueSql("getdate()");
    }

    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Commute> Commutes { get; set; } = null!;
    public DbSet<Neighborhood> Neighborhoods { get; set; } = null!;
}