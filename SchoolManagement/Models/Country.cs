using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Country
{
    public int Id { get; set; }

    public string? CountryCode { get; set; }

    public string? ShortName { get; set; }

    public string? FullName { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<State> States { get; set; } = new List<State>();
}
