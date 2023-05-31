using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class StudentLeave
{
    public int Id { get; set; }

    public int? LeaveId { get; set; }

    public string? Approved { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual Leave? Leave { get; set; }
}
