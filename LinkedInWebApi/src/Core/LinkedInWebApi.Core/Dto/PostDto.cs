namespace LinkedInWebApi.Core
{
    public class PostDto
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string FreeTxt { get; set; }
        public bool IsActive { get; set; }
        public int Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
