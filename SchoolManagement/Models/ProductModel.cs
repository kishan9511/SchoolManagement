using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class ProductModel
{
    public int Modelid { get; set; }

    public int? BrandId { get; set; }

    public string? ModelName { get; set; }

    public bool? Isdeleted { get; set; }

    public int? SubCategoryId { get; set; }

    public virtual ProductBrand? Brand { get; set; }

    public virtual ICollection<ProductEntry> ProductEntries { get; set; } = new List<ProductEntry>();

    public virtual ICollection<ProductSerise> ProductSerises { get; set; } = new List<ProductSerise>();

    public virtual SubCategory? SubCategory { get; set; }
}
