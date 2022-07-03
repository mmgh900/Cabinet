using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cabinet.Models.Configurations
{
    public class NeighborhoodConfiguration : IEntityTypeConfiguration<Neighborhood>
    {
        public void Configure(EntityTypeBuilder<Neighborhood> builder)
        {
            builder.HasData(
                new Neighborhood
                {
                    Id = 1,
                    Name = "Sanabad",
                },
                new Neighborhood
                {
                    Id = 2,
                    Name = "Kolahdoz",
                }
                ,
                new Neighborhood
                {
                    Id = 3,
                    Name = "Moalem",
                },
                new Neighborhood
                {
                    Id = 4,
                    Name = "Emam Reza",
                },
                new Neighborhood
                {
                    Id = 5,
                    Name = "Azadi",
                }
            );
        }
    }
}
