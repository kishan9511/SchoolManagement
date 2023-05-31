using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class ApprovedforExamination
{
    public int Id { get; set; }

    public int? RegistrationId { get; set; }

    public int? TeacherDetailsId { get; set; }

    public string? ExamHallNumber { get; set; }

    public bool? IsDeleted { get; set; }

    public int? SubjectTakenId { get; set; }

    public int? RoleId { get; set; }

    public int? SubjectId { get; set; }

    public virtual Registration? Registration { get; set; }

    public virtual RoleCreation? Role { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual SubjectTakenByTeacher? SubjectTaken { get; set; }

    public virtual TeacherDetail? TeacherDetails { get; set; }
}
