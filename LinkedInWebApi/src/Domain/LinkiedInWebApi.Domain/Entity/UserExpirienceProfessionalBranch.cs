﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LinkiedInWebApi.Domain.Entity;

public partial class UserExpirienceProfessionalBranch
{
    public int Id { get; set; }

    public int UserExperienceId { get; set; }

    public int TypeId { get; set; }

    public bool IsActive { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdateAt { get; set; }

    public virtual RfdtProfessionalBranch Type { get; set; }

    public virtual UserExperience UserExperience { get; set; }
}