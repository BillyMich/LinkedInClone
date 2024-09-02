namespace LinkedInWebApi.Core.Dto
{
    public class AdvertisementDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FreeTxt { get; set; }
        public int CreatorId { get; set; }
        public byte Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<int> ProfessionalBranches { get; set; }

    }
}
