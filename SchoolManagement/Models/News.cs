﻿using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class News
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Details { get; set; }

    public bool? Isdeleted { get; set; }
}
