using System;
using System.Collections.Generic;

namespace MPOS.WebMVC.Models;

public partial class SaleDetail
{
    public int InvoiceId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public double TotalPrice { get; set; }

    public DateTime Created { get; set; }

    public virtual Sale Invoice { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
