using System;
using System.Collections.Generic;

namespace MPOS.WebMVC.Models;

public partial class ViewProductWithCategory
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string Category { get; set; } = null!;

    public double SellingPrice { get; set; }

    public string Unit { get; set; } = null!;
}
