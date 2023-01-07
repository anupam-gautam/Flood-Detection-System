using System;
using System.Collections.Generic;

namespace Flood_Detection_System.Models;

public partial class UserDetail
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Location { get; set; }

    public bool? IsAactive { get; set; }
}
