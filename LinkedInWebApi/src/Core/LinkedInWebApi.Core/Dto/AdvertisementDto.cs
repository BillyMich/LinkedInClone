namespace LinkedInWebApi.Core
{
    public class AdvertisementDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FreeTxt { get; set; }
        public int CreatorId { get; set; }
        public byte Status { get; set; }
        public string ProfessionalBranche { get; set; }
        public string WorkingLocation { get; set; }
        public string JobType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
