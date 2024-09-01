namespace LinkedInWebApi.Core.Dto
{
    public class NewMessageDto
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Message { get; set; }
    }
}
