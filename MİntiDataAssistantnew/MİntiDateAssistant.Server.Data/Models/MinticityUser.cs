using System;
using System.Collections.Generic;

namespace MİntiDateAssistant.Server.Data.Models;

public partial class MinticityUser
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Salt { get; set; }

    public bool IsActive { get; set; }
}
