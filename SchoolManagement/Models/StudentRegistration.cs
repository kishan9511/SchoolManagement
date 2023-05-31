using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class StudentRegistration
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public string? StudentUsn { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? IsDeleted { get; set; }

    public string? Gender { get; set; }

    public string? AadharCard { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Feesinfo> Feesinfos { get; set; } = new List<Feesinfo>();

    public virtual ICollection<MarksEntry> MarksEntries { get; set; } = new List<MarksEntry>();

    public virtual ICollection<ResultEntry> ResultEntries { get; set; } = new List<ResultEntry>();

    public virtual RoleCreation? Role { get; set; }
}
