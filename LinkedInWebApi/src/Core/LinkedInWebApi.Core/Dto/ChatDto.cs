namespace LinkedInWebApi.Core
{
    public class ChatDto
    {
        public int Id { get; set; }

        public int UserChatingId { get; set; }

        public string Name { get; set; }

        public string? LastMessage { get; set; }

        public DateTime? LastMessageDate { get; set; }

    }
}
