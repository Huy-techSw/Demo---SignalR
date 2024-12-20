﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories.Models;

public partial class Pond
{
    public long Id { get; set; }

    public string PondName { get; set; }

    public long UserId { get; set; }

    public string ImageUrl { get; set; }

    public decimal? Size { get; set; }

    public decimal? Depth { get; set; }

    public string Shape { get; set; }

    public decimal? Volume { get; set; }

    public int? DrainCount { get; set; }

    public decimal? PumpCapacity { get; set; }

    public int? SkimmerCount { get; set; }

    public virtual ICollection<KoiFish> KoiFishes { get; set; } = new List<KoiFish>();

    public virtual User User { get; set; }

    public virtual ICollection<WaterParameter> WaterParameters { get; set; } = new List<WaterParameter>();
}