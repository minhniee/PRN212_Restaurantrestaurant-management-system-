using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class User
{
    public int Userid { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Fullname { get; set; }

    public string? Phone { get; set; }
}
