using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Leave
{
    public int Id { get; set; }

    public int? StudentDetailId { get; set; }

    public string? Usn { get; set; }

    public string? Name { get; set; }

    public string? Reason { get; set; }

    public string? Approved { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual ICollection<LeaveStatus> LeaveStatuses { get; set; } = new List<LeaveStatus>();

    public virtual StudentDetail? StudentDetail { get; set; }
}
