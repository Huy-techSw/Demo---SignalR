﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories.Models;

public partial class Role
{
    public long Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}