namespace LinkedInWebApi.Core
{
    public class CreateUserEducationDto
    {
        public string DegreeTitle { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsPublic { get; set; }
        public int EducationTypeId { get; set; }
    }
}
