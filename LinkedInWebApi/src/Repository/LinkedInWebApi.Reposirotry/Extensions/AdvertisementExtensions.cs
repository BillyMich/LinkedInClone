using LinkedInWebApi.Core;
using LinkiedInWebApi.Domain.Entity;

namespace LinkedInWebApi.Reposirotry.Extensions
{
    public static class AdvertisementExtensions
    {

        public static Advertisement ToAdvertisement(this CreateAdvertisementDto advertisementDto, int creatorId)
        {
            return new Advertisement
            {
                CreatorId = creatorId,
                Title = advertisementDto.Title,
                FreeTxt = advertisementDto.FreeTxt,
                AdvertismentProfessionalBranches = advertisementDto.ProfessionalBranche.ToRFDT<AdvertismentProfessionalBranch>(),
                AdvertismentWorkingLocations = advertisementDto.WorkingLocation.ToRFDT<AdvertismentWorkingLocation>(),
                AdvertisementJobTypes = advertisementDto.JobType.ToRFDT<AdvertisementJobType>(),
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now,
            };
        }

        private static List<T> ToRFDT<T>(this int value) where T : IAdvertismentDetail, new()
        {

            return new List<T> { new() { Id = value, IsActive = true, CreatedAt = DateTimeOffset.Now, UpdatedAt = DateTimeOffset.Now } };
        }


        public static AdvertisementDto ToAdvertisementDto(this Advertisement? advertisement)
        {
            return new AdvertisementDto
            {
                Id = advertisement.Id,
                Title = advertisement.Title,
                FreeTxt = advertisement.FreeTxt,
                CreatedAt = advertisement.CreatedAt.DateTime,
                UpdatedAt = advertisement.UpdatedAt.DateTime,
                ProfessionalBranches = advertisement.AdvertismentProfessionalBranches.Select(x => x.ProfessionalBranchId).ToList()

            };
        }

        public static Advertisement ToAdvertisement(this AdvertisementDto advertisementDto)
        {
            return new Advertisement
            {
                Id = advertisementDto.Id,
                Title = advertisementDto.Title,
                FreeTxt = advertisementDto.FreeTxt,
                CreatedAt = advertisementDto.CreatedAt,
                UpdatedAt = advertisementDto.UpdatedAt,
                AdvertismentProfessionalBranches = advertisementDto.ProfessionalBranches.Select(x => new AdvertismentProfessionalBranch { ProfessionalBranchId = x }).ToList()
            };
        }

        public static List<AdvertisementDto> ToAdvertisementDtos(this List<Advertisement> advertisements)
        {
            return advertisements.Select(x => x.ToAdvertisementDto()).ToList();
        }

        public static Advertisement ToUpdateAdvertisement(this Advertisement advertisement, AdvertisementDto advertisementDto)
        {
            advertisement.Title = advertisementDto.Title;
            advertisement.FreeTxt = advertisementDto.FreeTxt;
            advertisement.UpdatedAt = DateTimeOffset.Now;

            return advertisement;
        }

    }
}
