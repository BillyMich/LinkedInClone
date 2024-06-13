namespace LinkedInWebApi.Core
{
    public class UserDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public Role Role { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset DateUpdated { get; set; }
    }
}
