using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Checkresult
{
    public int Id { get; set; }

    public int? MarkId { get; set; }

    public int? ResultId { get; set; }

    public bool? IsDeleted { get; set; }

    public int? StudentDetailId { get; set; }

    public virtual MarksEntry? Mark { get; set; }

    public virtual ResultEntry? Result { get; set; }

    public virtual StudentDetail? StudentDetail { get; set; }
}
