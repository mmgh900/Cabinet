namespace Cabinet.Models;

public class Neighborhood
{
    public long Id { get; set; }
    public string Name { get; set; }

    public List<CabinetUser> Drivers { get; set; }

    public List<Address> Addresses { get; set; }
}