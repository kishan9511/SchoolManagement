﻿using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Login
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public bool? Isdeleted { get; set; }
}
