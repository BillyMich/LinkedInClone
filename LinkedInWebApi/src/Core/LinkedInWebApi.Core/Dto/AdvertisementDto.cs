namespace LinkedInWebApi.Core
{
    /// <summary>
    /// Represents an advertisement data transfer object.
    /// </summary>
    public class AdvertisementDto
    {
        /// <summary>
        /// Gets or sets the ID of the advertisement.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the advertisement.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the free text of the advertisement.
        /// </summary>
        public string FreeTxt { get; set; }

        /// <summary>
        /// Gets or sets the ID of the creator of the advertisement.
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the status of the advertisement.
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the professional branch of the advertisement.
        /// </summary>
        public int ProfessionalBranche { get; set; }

        /// <summary>
        /// Gets or sets the working location of the advertisement.
        /// </summary>
        public int WorkingLocation { get; set; }

        /// <summary>
        /// Gets or sets the job type of the advertisement.
        /// </summary>
        public int JobType { get; set; }

        /// <summary>
        /// Gets or sets the creation date and time of the advertisement.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the last update date and time of the advertisement.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        public int TimesViewed { get; set; }
    }
}
