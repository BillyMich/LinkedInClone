namespace LinkedInWebApi.Core
{
    /// <summary>
    /// Represents the data transfer object for creating an advertisement.
    /// </summary>
    public class CreateAdvertisementDto
    {
        /// <summary>
        /// Gets or sets the title of the advertisement.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the free text of the advertisement.
        /// </summary>
        public string FreeTxt { get; set; }

        /// <summary>
        /// Gets or sets the status of the advertisement.
        /// </summary>
        public byte Status { get; set; }

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
    }
}