using System;
using System.Collections.Generic;

namespace MPOS.WebMVC.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
