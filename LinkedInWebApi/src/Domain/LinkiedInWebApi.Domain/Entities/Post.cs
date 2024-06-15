﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LinkiedInWebApi.Domain.Entities;

public partial class Post
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string FreeTxt { get; set; }

    public bool IsActive { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public DateTimeOffset DateUpdated { get; set; }

    public int CreatorId { get; set; }

    public string MultimediaUrlPath { get; set; }

    public byte Status { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User Creator { get; set; }
}