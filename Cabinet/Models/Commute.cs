using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Cabinet.Models;

public class Commute
{
    public long Id { get; set; }

    public DateTime DateRequested { get; set; }

    public DateTime? DateEnder { get; set; }

    public Address Origin { get; set; }


    public Address Destination { get; set; }


    public int Cost { get; set; }

    public Commuter Commuter { get; set; }

    public Driver? Driver { get; set; }
    
    public CommuteStatus Status   { get; set; }
    
    public int? Score   { get; set; }

}

public enum CommuteStatus
{
    WaitingForDriver,
    InProgress,
    WaitingForPayment,
    Completed // Payed for
}