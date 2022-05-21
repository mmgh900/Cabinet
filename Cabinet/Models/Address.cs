using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace Cabinet.Models;

public class Address
{
    public long Id { get; set; }
    
    public Neighborhood Neighborhood { get; set; }

    [Required] 
    public string Details { get; set; }
    
    public string Location { get; set; }
}