using Cabinet.Models;

namespace Cabinet.Classes
{
    public class CommuteAddDTO
    {
        public long? DestinationNeighborhoodId { get; set; }
        public string? DestinationDetails { get; set; }

        public long? DestinationId { get; set; }

        public long? OriginNeighborhoodId { get; set; }
        public string? OriginDetails { get; set; }

        public long? OriginId { get; set; }

        public float Price { get; set; }

    }
    public class CommuteOutputDTO
    {
        public long Id { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }

        public string CommuterName { get; set; }
        public string CommuterEmail { get; set; }
        public string? DriverName { get; set; }
        public double? DriverScore { get; set; }
        public string? DriverEmail { get; set; }
        public float Price { get; set; }

        public string RequestTime { get; set; }

        public string Status { get; set; }
        public int? Score { get;  set; }
    }

    public static class CommuteHelper
    {
        public static string ToStatusString(this CommuteStatus commuteStatus)
        {
            switch (commuteStatus)
            {
                case CommuteStatus.WaitingForPayment:
                    return "Waiting For Payment";
                case CommuteStatus.InProgress:
                    return "In Progress";
                case CommuteStatus.WaitingForDriver:
                    return "Waiting For Driver";
                case CommuteStatus.Completed:
                    return "Completed";
                case CommuteStatus.Canceled:
                    return "Canceled";
                default:
                    return "Unknown Status";
            }
        }
    }

}

