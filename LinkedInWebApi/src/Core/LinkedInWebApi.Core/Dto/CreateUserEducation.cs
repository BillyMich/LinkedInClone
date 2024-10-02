namespace LinkedInWebApi.Core
{
    public class CreateUserEducationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public int EducationTypeId { get; set; }

    }
}
