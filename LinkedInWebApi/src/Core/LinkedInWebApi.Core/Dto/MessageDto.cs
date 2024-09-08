namespace LinkedInWebApi.Core
{
    public class MessageDto
    {
        public int SenderId { get; set; }

        public string FreeTxt { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
