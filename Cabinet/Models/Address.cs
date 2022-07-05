using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Cabinet.Models;

public class Address
{
    public long Id { get; set; }


    public long NeighborhoodId { get; set; }
    public Neighborhood Neighborhood { get; set; }

    [Required] 
    public string Details { get; set; }


    

}