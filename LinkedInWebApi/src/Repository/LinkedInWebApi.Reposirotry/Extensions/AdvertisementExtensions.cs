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
                Title = advertisementDto.Title,
                FreeTxt = advertisementDto.FreeTxt,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now,
                CreatorId = creatorId
            };
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
