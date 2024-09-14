namespace LinkedInWebApi.Core
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string FreeTxt { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
