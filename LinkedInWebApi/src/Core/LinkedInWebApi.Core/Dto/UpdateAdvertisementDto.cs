namespace LinkedInWebApi.Core
{
    public class UpdateAdvertisementDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FreeTxt { get; set; }
        public byte Status { get; set; }
        public int ProfessionalBranche { get; set; }
        public int WorkingLocation { get; set; }
        public int JobType { get; set; }
    }
}
