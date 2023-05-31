using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string? SubjectName { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<ApprovedforExamination> ApprovedforExaminations { get; set; } = new List<ApprovedforExamination>();

    public virtual ICollection<MarksEntry> MarksEntries { get; set; } = new List<MarksEntry>();

    public virtual ICollection<ResultEntry> ResultEntries { get; set; } = new List<ResultEntry>();

    public virtual ICollection<StudentDetail> StudentDetails { get; set; } = new List<StudentDetail>();

    public virtual ICollection<SubjectTakenByTeacher> SubjectTakenByTeachers { get; set; } = new List<SubjectTakenByTeacher>();
}
