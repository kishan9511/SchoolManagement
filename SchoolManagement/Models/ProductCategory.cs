using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual ICollection<ProductBrand> ProductBrands { get; set; } = new List<ProductBrand>();

    public virtual ICollection<ProductEntry> ProductEntries { get; set; } = new List<ProductEntry>();

    public virtual ICollection<ProductSerise> ProductSerises { get; set; } = new List<ProductSerise>();

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
}
