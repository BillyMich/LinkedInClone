﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LinkiedInWebApi.Domain.Entity;

public partial class UserEducationProfessionalBranch
{
    public int Id { get; set; }

    public int UserEducationId { get; set; }

    public int ProfessionalBranchId { get; set; }

    public bool IsActive { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual RfdtProfessionalBranch ProfessionalBranch { get; set; }

    public virtual UserEducation UserEducation { get; set; }
}