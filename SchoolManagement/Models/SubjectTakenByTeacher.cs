using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class SubjectTakenByTeacher
{
    public int Id { get; set; }

    public int? RegistrationId { get; set; }

    public string? SubjectName { get; set; }

    public string? Time { get; set; }

    public bool? IsDeleted { get; set; }

    public int? RoleId { get; set; }

    public int? SubjectId { get; set; }

    public int? TeacherDetailsId { get; set; }

    public virtual ICollection<ApprovedforExamination> ApprovedforExaminations { get; set; } = new List<ApprovedforExamination>();

    public virtual Registration? Registration { get; set; }

    public virtual RoleCreation? Role { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual TeacherDetail? TeacherDetails { get; set; }
}
