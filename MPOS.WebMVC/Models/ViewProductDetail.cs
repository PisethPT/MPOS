using System;
using System.Collections.Generic;

namespace MPOS.WebMVC.Models;

public partial class ViewProductDetail
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public double CostPrice { get; set; }

    public double SellingPrice { get; set; }

    public string Unit { get; set; } = null!;

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }
}
