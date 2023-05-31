using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class TeacherDetail
{
    public int Id { get; set; }

    public int? RegistrationId { get; set; }

    public string? Geander { get; set; }

    public string? Qulification { get; set; }

    public string? Address { get; set; }

    public string? JoiningDate { get; set; }

    public string? AccountNumber { get; set; }

    public string? Attendance { get; set; }

    public string? TotalLeaves { get; set; }

    public bool? IsDeleted { get; set; }

    public int? RoleId { get; set; }

    public string? Phone { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<ApprovedforExamination> ApprovedforExaminations { get; set; } = new List<ApprovedforExamination>();

    public virtual Registration? Registration { get; set; }

    public virtual RoleCreation? Role { get; set; }

    public virtual ICollection<SubjectTakenByTeacher> SubjectTakenByTeachers { get; set; } = new List<SubjectTakenByTeacher>();
}
