using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class City
{
    public int Id { get; set; }

    public int? StateId { get; set; }

    public string? FullName { get; set; }

    public int? Pincode { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual State? State { get; set; }
}
