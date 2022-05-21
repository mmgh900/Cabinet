using Microsoft.AspNetCore.Identity;

namespace Cabinet.Models;

public class Driver : IdentityUser
{
    public long Id { get; set; }
    public List<Neighborhood> WorkingNeighborhood;
    public bool IsBlocked { get; set; }
    public List<Commute> Commutes { get; set; }
}