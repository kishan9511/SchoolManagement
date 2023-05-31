using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class State
{
    public int Id { get; set; }

    public int? CountryId { get; set; }

    public string? ShortName { get; set; }

    public string? FullName { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country? Country { get; set; }
}
