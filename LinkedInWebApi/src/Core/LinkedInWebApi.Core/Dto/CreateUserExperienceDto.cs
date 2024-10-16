
namespace LinkedInWebApi.Core
{
    public class CreateUserExperienceDto
    {
        public string Title { get; set; }
        public string FreeTxt { get; set; }
        public bool IsPublic { get; set; }
        public DateOnly StartedAt { get; set; }
        public DateOnly EndedAt { get; set; }
    }
}
