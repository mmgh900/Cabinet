using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cabinet.Models
{
    public class CabinetUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }


        public List<Address> SavedAddresses { get; set; }

        [InverseProperty("Driver")]
        public List<Commute> DriverCommutes { get; set; }

        [InverseProperty("Commuter")]
        public List<Commute>? CommuterCommutes { get; set; }

        public List<Neighborhood>? WorkingNeighborhoods { get; set; }
        public bool IsBlocked { get; set; }
    }
}
