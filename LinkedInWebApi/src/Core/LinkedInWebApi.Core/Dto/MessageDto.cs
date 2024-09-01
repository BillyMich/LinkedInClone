namespace LinkedInWebApi.Core.Dto
{
    public class MessageDto
    {
        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
