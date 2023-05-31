using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Feesinfo
{
    public int Id { get; set; }

    public int? RegistrationId { get; set; }

    public string? TotalFees { get; set; }

    public bool? IsDeleted { get; set; }

    public int? StudentRegistrationId { get; set; }

    public int? StudentDetailId { get; set; }

    public string? PaidFess { get; set; }

    public string? DueFees { get; set; }

    public virtual Registration? Registration { get; set; }

    public virtual StudentDetail? StudentDetail { get; set; }

    public virtual StudentRegistration? StudentRegistration { get; set; }
}
