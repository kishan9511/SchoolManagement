using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class LeaveStatus
{
    public int Id { get; set; }

    public int? LeaveId { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual Leave? Leave { get; set; }
}
