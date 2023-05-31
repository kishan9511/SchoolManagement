using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class StudentAttendance
{
    public int Id { get; set; }

    public int? StudentDetailId { get; set; }

    public string? Attendance { get; set; }

    public bool? Isdeleted { get; set; }

    public string? Date { get; set; }

    public virtual StudentDetail? StudentDetail { get; set; }
}
