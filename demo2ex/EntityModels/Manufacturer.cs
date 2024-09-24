using System;
using System.Collections.Generic;

namespace demo2ex.EntityModels;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? Startdate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
