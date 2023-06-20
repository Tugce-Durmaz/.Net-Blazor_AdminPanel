using System;
using System.Collections.Generic;

namespace MİntiDateAssistant.Server.Data.Models;

public partial class Guest
{
    public int GuestId { get; set; }

    public int? SchoolId { get; set; }

    public int? CityId { get; set; }

    public string? PersonalNumber { get; set; }

    public string? GuestName { get; set; }

    public DateTime? BirthDate { get; set; }

    public int? BirthPlace { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? GenderId { get; set; }

    public int? DealerId { get; set; }

    public int? BloodId { get; set; }

    public int? SizeId { get; set; }

    public int? SmokingId { get; set; }
}
