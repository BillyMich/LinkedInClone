﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LinkiedInWebApi.Domain.Entity;

public partial class ProfessionalBranch
{
    public int Id { get; set; }

    public string Name { get; set; }

    public bool? IsActive { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public virtual ICollection<AdvertismentProfessionalBranch> AdvertismentProfessionalBranches { get; set; } = new List<AdvertismentProfessionalBranch>();

    public virtual ICollection<UserEducationProfessionalBranch> UserEducationProfessionalBranches { get; set; } = new List<UserEducationProfessionalBranch>();

    public virtual ICollection<UserExpirienceProfessionalBranch> UserExpirienceProfessionalBranches { get; set; } = new List<UserExpirienceProfessionalBranch>();
}