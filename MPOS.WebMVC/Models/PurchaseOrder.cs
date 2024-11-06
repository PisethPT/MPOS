using System;
using System.Collections.Generic;

namespace MPOS.WebMVC.Models;

public partial class PurchaseOrder
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int SupplierId { get; set; }

    public double TotalAmount { get; set; }

    public double TotalPaid { get; set; }

    public double TotalRemain { get; set; }

    public DateTime Created { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
