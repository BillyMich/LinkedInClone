namespace LinkedInWebApi.Core
{
    public class PostNotificationDto
    {
        public List<CommentNotificationDto> CommentNotifications { get; set; }

        public List<PostReactionDto> ReactionsNotifications { get; set; }
    }

    public class CommentNotificationDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string CommentTxt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }

    public class PostReactionDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

    }


}
