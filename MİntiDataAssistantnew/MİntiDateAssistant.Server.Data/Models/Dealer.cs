using System;
using System.Collections.Generic;

namespace MİntiDateAssistant.Server.Data.Models;

public partial class Dealer
{
    public int DealerId { get; set; }

    public string? DealerName { get; set; }

    public int? CityId { get; set; }
}
