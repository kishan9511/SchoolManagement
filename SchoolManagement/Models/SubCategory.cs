using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class SubCategory
{
    public int Id { get; set; }

    public int? ProductCategoryId { get; set; }

    public string? Name { get; set; }

    public string? Icon { get; set; }

    public bool? IsModelOrSerise { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual ICollection<ProductBrand> ProductBrands { get; set; } = new List<ProductBrand>();

    public virtual ProductCategory? ProductCategory { get; set; }

    public virtual ICollection<ProductEntry> ProductEntries { get; set; } = new List<ProductEntry>();

    public virtual ICollection<ProductModel> ProductModels { get; set; } = new List<ProductModel>();

    public virtual ICollection<ProductSerise> ProductSerises { get; set; } = new List<ProductSerise>();
}
