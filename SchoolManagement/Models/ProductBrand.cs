using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class ProductBrand
{
    public int BrandId { get; set; }

    public string? BrandName { get; set; }

    public bool? Isdeleted { get; set; }

    public int? ProductCategoryId { get; set; }

    public int? SubCategoryId { get; set; }

    public virtual ProductCategory? ProductCategory { get; set; }

    public virtual ICollection<ProductEntry> ProductEntries { get; set; } = new List<ProductEntry>();

    public virtual ICollection<ProductModel> ProductModels { get; set; } = new List<ProductModel>();

    public virtual ICollection<ProductSerise> ProductSerises { get; set; } = new List<ProductSerise>();

    public virtual SubCategory? SubCategory { get; set; }
}
