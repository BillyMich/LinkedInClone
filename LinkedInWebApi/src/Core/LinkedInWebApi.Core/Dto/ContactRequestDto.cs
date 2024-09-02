﻿namespace LinkedInWebApi.Core.Dto
{
    public class ContactRequestDto
    {
        public int Id { get; set; }
        public int UserRequestId { get; set; }
        public int UserResiverId { get; set; }
        public bool IsActive { get; set; }
        public bool IsAccepted { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

    }
}
