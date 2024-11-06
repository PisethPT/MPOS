using System;
using System.Collections.Generic;

namespace MPOS.WebMVC.Models;

public partial class VTopProduct
{
    public int InvoiceId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Category { get; set; }

    public int Quantity { get; set; }

    public double TotalPrice { get; set; }

    public DateTime Created { get; set; }
}
