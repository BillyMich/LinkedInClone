﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LinkiedInWebApi.Domain.Entity;

public partial class PostComment
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public int CreatorId { get; set; }

    public string FreeTxt { get; set; }

    public bool IsActive { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual User Creator { get; set; }

    public virtual Post Post { get; set; }
}