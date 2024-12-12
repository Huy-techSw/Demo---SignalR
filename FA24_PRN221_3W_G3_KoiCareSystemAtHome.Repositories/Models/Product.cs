﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories.Models;

public partial class Product
{
    public long Id { get; set; }

    public string ProductName { get; set; }

    public string Description { get; set; }

    public string ProductType { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public string Manufacturer { get; set; }

    public string ImageUrl { get; set; }

    public DateTime? Expiration { get; set; }

    public string UsageInstruction { get; set; }

    public long CategoryId { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}