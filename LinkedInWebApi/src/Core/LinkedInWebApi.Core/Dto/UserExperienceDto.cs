
namespace LinkedInWebApi.Core
{
    public class UserExperienceDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string FreeTxt { get; set; }
        public bool IsPublic { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateOnly StartedAt { get; set; }
        public DateOnly EndedAt { get; set; }
    }
}
