﻿using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public bool? Isdeleted { get; set; }
}
