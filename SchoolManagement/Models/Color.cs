using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Color
{
    public int Colorid { get; set; }

    public string? ColorName { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
}
