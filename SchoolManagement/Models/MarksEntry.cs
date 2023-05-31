using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class MarksEntry
{
    public int Id { get; set; }

    public int? RegistrationId { get; set; }

    public int? ExamId { get; set; }

    public string? Marks { get; set; }

    public bool? IsDeleted { get; set; }

    public int? RoleId { get; set; }

    public int? StudentRegistrationId { get; set; }

    public int? SubjectId { get; set; }

    public int? StudentDetailId { get; set; }

    public string? TotalMakes { get; set; }

    public string? PassingMarks { get; set; }

    public virtual ICollection<Checkresult> Checkresults { get; set; } = new List<Checkresult>();

    public virtual Exam? Exam { get; set; }

    public virtual Registration? Registration { get; set; }

    public virtual ICollection<ResultEntry> ResultEntries { get; set; } = new List<ResultEntry>();

    public virtual RoleCreation? Role { get; set; }

    public virtual StudentDetail? StudentDetail { get; set; }

    public virtual ICollection<StudentDetail> StudentDetails { get; set; } = new List<StudentDetail>();

    public virtual StudentRegistration? StudentRegistration { get; set; }

    public virtual Subject? Subject { get; set; }
}
