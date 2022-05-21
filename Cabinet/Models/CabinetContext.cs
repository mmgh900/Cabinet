using Microsoft.EntityFrameworkCore;

namespace Cabinet.Models;

public class CabinetContext : DbContext
{
    public CabinetContext(DbContextOptions<CabinetContext> options) : base(options)
    {
        
    }

    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Commute> Commutes { get; set; } = null!;
    public DbSet<Commuter> Commuters { get; set; } = null!;
    public DbSet<Driver> Drivers { get; set; } = null!;
    public DbSet<Neighborhood> Neighborhoods { get; set; } = null!;
}