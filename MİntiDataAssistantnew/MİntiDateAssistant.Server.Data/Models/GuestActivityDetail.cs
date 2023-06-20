using System;
using System.Collections.Generic;

namespace MİntiDateAssistant.Server.Data.Models;

public partial class GuestActivityDetail
{
    public int DetailId { get; set; }

    public int? ActivityId { get; set; }

    public int? GuestId { get; set; }

    public int? TravelTypeId { get; set; }

    public DateTime? ArrivalDate { get; set; }

    public DateTime? DepartureDate { get; set; }

    public DateTime? TransferDate { get; set; }

    public DateTime? CheckInDate { get; set; }

    public DateTime? CheckOutDate { get; set; }

    public string? RoomNumber { get; set; }

    public int? RoommateId1 { get; set; }

    public int? RoommateId2 { get; set; }

    public string? Description { get; set; }
}
