using System;
using System.Collections.Generic;

namespace MPOS.WebMVC.Models;

public partial class Stock
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Product? Product { get; set; }
}
