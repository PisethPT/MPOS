using System;
using System.Collections.Generic;

namespace MPOS.WebMVC.Models;

public partial class Sale
{
    public int InvoiceId { get; set; }

    public int EmployeeId { get; set; }

    public int CustomerId { get; set; }

    public double Amount { get; set; }

    public double AmountPaid { get; set; }

    public double AmountRemain { get; set; }

    public DateTime Created { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
