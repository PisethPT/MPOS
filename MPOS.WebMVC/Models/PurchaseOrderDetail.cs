using System;
using System.Collections.Generic;

namespace MPOS.WebMVC.Models;

public partial class PurchaseOrderDetail
{
    public int PurchaseOrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public double TotalPrice { get; set; }

    public DateTime Created { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;
}
