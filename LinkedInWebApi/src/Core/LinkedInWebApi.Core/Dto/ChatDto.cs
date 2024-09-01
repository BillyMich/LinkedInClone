namespace LinkedInWebApi.Core.Dto
{
    public class ChatDto
    {
        public string Name { get; set; }

        public string? LastMessage { get; set; }

        public DateTime? LastMessageDate { get; set; }

        public int? UserChatingId { get; set; }
    }
}
