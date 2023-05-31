using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class StudentDetail
{
    public int Id { get; set; }

    public string? Gender { get; set; }

    public string? Class { get; set; }

    public string? Address { get; set; }

    public string? Attendance { get; set; }

    public bool? IsDeleted { get; set; }

    public int? RoleId { get; set; }

    public string? Phone { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Usn { get; set; }

    public int? SubjectId { get; set; }

    public int? ResultEntryid { get; set; }

    public int? MarksId { get; set; }

    public virtual ICollection<Checkresult> Checkresults { get; set; } = new List<Checkresult>();

    public virtual ICollection<Feesinfo> Feesinfos { get; set; } = new List<Feesinfo>();

    public virtual ICollection<Leave> Leaves { get; set; } = new List<Leave>();

    public virtual MarksEntry? Marks { get; set; }

    public virtual ICollection<MarksEntry> MarksEntries { get; set; } = new List<MarksEntry>();

    public virtual ICollection<ResultEntry> ResultEntries { get; set; } = new List<ResultEntry>();

    public virtual ResultEntry? ResultEntry { get; set; }

    public virtual RoleCreation? Role { get; set; }

    public virtual ICollection<StudentAttendance> StudentAttendances { get; set; } = new List<StudentAttendance>();

    public virtual Subject? Subject { get; set; }
}
