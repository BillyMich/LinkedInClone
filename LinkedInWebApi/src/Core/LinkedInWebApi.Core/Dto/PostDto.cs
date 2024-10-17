namespace LinkedInWebApi.Core
{
    public class PostDto
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string FreeTxt { get; set; }
        public bool IsActive { get; set; }
        public int Status { get; set; }
        public int PostReactions { get; set; }
        public List<CommentDto> Comments { get; set; }
        public FileDto FileDto { get; set; }
        public int Points { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
