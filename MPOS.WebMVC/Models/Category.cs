using System;
using System.Collections.Generic;

namespace MPOS.WebMVC.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
