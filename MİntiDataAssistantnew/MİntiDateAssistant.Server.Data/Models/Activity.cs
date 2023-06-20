using System;
using System.Collections.Generic;

namespace MİntiDateAssistant.Server.Data.Models;

public partial class Activity
{
    public int ActivityId { get; set; }

    public string? ActivityName { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Location { get; set; }

    public bool? IsActive { get; set; }
}
