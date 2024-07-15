using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class Staff
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? Phone { get; set; }
}
