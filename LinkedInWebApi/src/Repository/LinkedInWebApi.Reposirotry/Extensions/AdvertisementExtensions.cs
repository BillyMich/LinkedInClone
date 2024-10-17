using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain.Entity;

namespace LinkedInWebApi.Reposirotry.Extensions
{
    /// <summary>
    /// Extension methods for the Advertisement class.
    /// </summary>
    public static class AdvertisementExtensions
    {
        /// <summary>
        /// Converts a CreateAdvertisementDto object to an Advertisement object.
        /// </summary>
        /// <param name="advertisementDto">The CreateAdvertisementDto object.</param>
        /// <param name="creatorId">The creator ID.</param>
        /// <returns>The converted Advertisement object.</returns>
        public static Advertisement ToAdvertisement(this CreateAdvertisementDto advertisementDto, int creatorId)
        {
            return new Advertisement
            {
                CreatorId = creatorId,
                Title = advertisementDto.Title,
                FreeTxt = advertisementDto.FreeTxt,
                Status = advertisementDto.Status,
                IsActive = true,
                AdvertismentProfessionalBranches = advertisementDto.ProfessionalBranche.ToRFDT<AdvertismentProfessionalBranch>(),
                AdvertismentWorkingLocations = advertisementDto.WorkingLocation.ToRFDT<AdvertismentWorkingLocation>(),
                AdvertisementJobTypes = advertisementDto.JobType.ToRFDT<AdvertisementJobType>(),
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now,
            };
        }

        /// <summary>
        /// Converts an Advertisement object to an AdvertisementDto object.
        /// </summary>
        /// <param name="advertisement">The Advertisement object.</param>
        /// <returns>The converted AdvertisementDto object.</returns>
        public static AdvertisementDto ToAdvertisementDto(this Advertisement? advertisement) => new AdvertisementDto
        {
            Id = advertisement?.Id ?? 0,
            Title = advertisement?.Title ?? string.Empty,
            FreeTxt = advertisement?.FreeTxt ?? string.Empty,
            CreatorId = advertisement?.CreatorId ?? 0,
            ProfessionalBranche = advertisement?.AdvertismentProfessionalBranches.FirstOrDefault()?.TypeId ?? 0,
            WorkingLocation = advertisement?.AdvertismentWorkingLocations.FirstOrDefault()?.TypeId ?? 0,
            JobType = advertisement?.AdvertisementJobTypes.FirstOrDefault()?.TypeId ?? 0,
            Status = advertisement?.Status ?? default(byte),
            CreatedAt = advertisement?.CreatedAt.DateTime ?? DateTime.MinValue,
            UpdatedAt = advertisement?.UpdatedAt.DateTime ?? DateTime.MinValue,
            TimesViewed = advertisement?.TimesViewed ?? 0,
        };

        /// <summary>
        /// Converts a list of Advertisement objects to a list of AdvertisementDto objects.
        /// </summary>
        /// <param name="advertisements">The list of Advertisement objects.</param>
        /// <returns>The converted list of AdvertisementDto objects.</returns>
        public static List<AdvertisementDto> ToAdvertisementDtos(this List<Advertisement> advertisements)
        {
            return advertisements.Select(x => x.ToAdvertisementDto()).ToList();
        }

        /// <summary>
        /// Updates an Advertisement object with the values from an UpdateAdvertisementDto object.
        /// </summary>
        /// <param name="advertisement">The Advertisement object to update.</param>
        /// <param name="advertisementDto">The UpdateAdvertisementDto object.</param>
        /// <returns>The updated Advertisement object.</returns>
        public static Advertisement ToUpdateAdvertisement(this Advertisement advertisement, UpdateAdvertisementDto advertisementDto)
        {
            advertisement.InActivateTypesBeforeUpdate();
            advertisement.Title = advertisementDto.Title;
            advertisement.FreeTxt = advertisementDto.FreeTxt;
            advertisement.AdvertismentProfessionalBranches = advertisementDto.ProfessionalBranche.ToRFDT<AdvertismentProfessionalBranch>();
            advertisement.AdvertismentWorkingLocations = advertisementDto.WorkingLocation.ToRFDT<AdvertismentWorkingLocation>();
            advertisement.AdvertisementJobTypes = advertisementDto.JobType.ToRFDT<AdvertisementJobType>();
            advertisement.Status = advertisementDto.Status;
            advertisement.UpdatedAt = DateTimeOffset.Now;
            return advertisement;
        }

        /// <summary>
        /// Inactivates the types of the Advertisement object before updating.
        /// </summary>
        /// <param name="advertisement">The Advertisement object.</param>
        private static void InActivateTypesBeforeUpdate(this Advertisement advertisement)
        {
            advertisement.AdvertisementJobTypes.Select(x => x.IsActive = false);
            advertisement.AdvertismentProfessionalBranches.Select(x => x.IsActive = false);
            advertisement.AdvertismentWorkingLocations.Select(x => x.IsActive = false);
        }

        /// <summary>
        /// Converts an integer value to a list of T objects.
        /// </summary>
        /// <typeparam name="T">The type of the objects in the list.</typeparam>
        /// <param name="value">The integer value.</param>
        /// <returns>The list of T objects.</returns>
        private static List<T> ToRFDT<T>(this int value) where T : IAdvertismentDetail, new()
        {
            return new List<T> { new() { TypeId = value, IsActive = true, CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now } };
        }

        public static AdvertisementApply ToAdvertisementApply(this int advertisementApplyDto, int userId)
        {
            return new AdvertisementApply
            {
                AdvertismentId = advertisementApplyDto,
                UserId = userId,
                IsActive = true,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };
        }

        public static List<ApplicationNotificationDto> ToApplicationNotificationDtos(this List<Advertisement> advertisements)
        {
            return advertisements.SelectMany(x => x.AdvertisementApplies.Select(y => new ApplicationNotificationDto
            {
                UserName = y.User.Name,
                ApplicationTitle = x.Title,
            })).ToList();
        }

    }
}
