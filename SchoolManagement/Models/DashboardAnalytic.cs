using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class DashboardAnalytic
{
    public int Id { get; set; }

    public string? StudentsTotal { get; set; }

    public string? TeachersTotal { get; set; }

    public string? ClassesTotal { get; set; }

    public string? Events { get; set; }

    public bool? IsDeleted { get; set; }
}
