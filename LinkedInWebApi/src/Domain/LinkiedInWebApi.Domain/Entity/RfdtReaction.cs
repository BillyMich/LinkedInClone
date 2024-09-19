﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LinkiedInWebApi.Domain.Entity;

public partial class RfdtReaction
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string FileName { get; set; }

    public byte[] DataOfFile { get; set; }

    public bool IsActive { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual ICollection<PostReaction> PostReactions { get; set; } = new List<PostReaction>();
}