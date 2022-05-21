using Microsoft.AspNetCore.Identity;

namespace Cabinet.Models;

public class Commuter : IdentityUser
{
    public long Id { get; set; }
    public List<Address> SavedAddresses;
    public List<Commute> Commutes { get; set; }
}