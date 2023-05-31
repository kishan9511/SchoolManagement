using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Exam
{
    public int Id { get; set; }

    public string? SubjectName { get; set; }

    public string? ExamTiming { get; set; }

    public string? ExamDuration { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<MarksEntry> MarksEntries { get; set; } = new List<MarksEntry>();

    public virtual ICollection<ResultEntry> ResultEntries { get; set; } = new List<ResultEntry>();
}
