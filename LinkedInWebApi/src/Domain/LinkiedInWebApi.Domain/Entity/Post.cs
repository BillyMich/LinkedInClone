﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LinkiedInWebApi.Domain.Entity;

public partial class Post
{
    public int Id { get; set; }

    public int CreatorId { get; set; }

    public string FreeTxt { get; set; }

    public short Status { get; set; }

    public bool IsActive { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual User Creator { get; set; }

    public virtual ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();

    public virtual ICollection<PostMultimedia> PostMultimedia { get; set; } = new List<PostMultimedia>();

    public virtual ICollection<PostReaction> PostReactions { get; set; } = new List<PostReaction>();
}