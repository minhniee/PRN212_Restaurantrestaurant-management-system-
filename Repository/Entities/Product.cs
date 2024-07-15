namespace Repository.Entities;

public partial class Product
{
    public int PId { get; set; }

    public string? PName { get; set; }

    public double? PPrice { get; set; }

    public int? CategoryId { get; set; }
    public string CategoryName { get; set; }

    public byte[]? PImage { get; set; }

    public virtual Category? Category { get; set; }
}
