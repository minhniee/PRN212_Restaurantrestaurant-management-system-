using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class Table
{
    public int TableId { get; set; }

    public string? TableName { get; set; }
}
