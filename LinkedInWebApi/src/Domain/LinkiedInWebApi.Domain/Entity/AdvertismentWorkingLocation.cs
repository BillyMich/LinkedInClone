﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LinkiedInWebApi.Domain.Entity;

public partial class AdvertismentWorkingLocation : IAdvertismentDetail
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public int AdvertisementId { get; set; }

    public bool IsActive { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual Advertisement Advertisement { get; set; }

    public virtual RfdtWorkingLocation Type { get; set; }
}