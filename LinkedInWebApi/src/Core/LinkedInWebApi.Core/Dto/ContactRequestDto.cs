namespace LinkedInWebApi.Core
{
    public class ContactRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserResiverId { get; set; }
        public bool IsActive { get; set; }
        public bool IsAccepted { get; set; }
    }
}
