using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Registration
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? IsDeleted { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<ApprovedforExamination> ApprovedforExaminations { get; set; } = new List<ApprovedforExamination>();

    public virtual ICollection<Feesinfo> Feesinfos { get; set; } = new List<Feesinfo>();

    public virtual ICollection<MarksEntry> MarksEntries { get; set; } = new List<MarksEntry>();

    public virtual ICollection<ResultEntry> ResultEntries { get; set; } = new List<ResultEntry>();

    public virtual RoleCreation? Role { get; set; }

    public virtual ICollection<SubjectTakenByTeacher> SubjectTakenByTeachers { get; set; } = new List<SubjectTakenByTeacher>();

    public virtual ICollection<TeacherDetail> TeacherDetails { get; set; } = new List<TeacherDetail>();
}
