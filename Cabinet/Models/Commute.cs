using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Cabinet.Models;

public class Commute
{
    public long Id { get; set; }
    public DateTime DateRequested { get; set; }

    public DateTime? DateEnded { get; set; }

    public long OriginId { get; set; }
    public virtual Address Origin { get; set; }

    public long DestinationId { get; set; }
    public virtual Address Destination { get; set; }

    public float Price { get; set; }
    public string CommuterId { get; set; }
    public virtual CabinetUser Commuter { get; set; }


    public string? DriverId { get; set; }
    public virtual CabinetUser? Driver { get; set; }

    public CommuteStatus Status { get; set; }

    public int? Score { get; set; }

}

public enum CommuteStatus
{
    WaitingForDriver = 0,
    InProgress = 1,
    WaitingForPayment = 2,
    Completed = 3, // Payed for,
    Canceled = 4
}