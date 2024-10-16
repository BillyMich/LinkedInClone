using LinkedInWebApi.Core;
using LinkedInWebApi.Reposirotry.Extensions;
using LinkiedInWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkedInWebApi.Reposirotry.Commands
{
    public class AdvertisementReadCommands : IAdvertisementReadCommands
    {

        private readonly LinkedInDbContext _linkedInDbContext;

        public AdvertisementReadCommands(LinkedInDbContext linkedInDbContext)
        {
            _linkedInDbContext = linkedInDbContext;
        }

        public async Task<List<UserDto>> ApplyApplicantAsync(int id)
        {
            var userListApplied = await _linkedInDbContext.AdvertisementApplies
                .Include(u => u.User)
                .Where(x => x.AdvertismentId == id)
                .Select(x => x.User)
                .ToListAsync();

            return userListApplied.ToUserDtoList();

        }

        public async Task<AdvertisementDto?> GetAdvertisment(int id)
        {
            var advertisement = await _linkedInDbContext.Advertisements
                .Include(u => u.AdvertismentProfessionalBranches)
                .Include(u => u.AdvertisementJobTypes)
                .Include(u => u.AdvertismentWorkingLocations)
                .Include(u => u.Creator)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (advertisement == null)
            {
                return null;
            }

            return advertisement.ToAdvertisementDto();
        }

        public async Task<List<AdvertisementDto>?> GetAdvertisments()
        {
            var advertisement = await _linkedInDbContext.Advertisements
                .Include(u => u.AdvertismentProfessionalBranches)
                .Include(u => u.AdvertisementJobTypes)
                .Include(u => u.AdvertismentWorkingLocations)
                .Include(u => u.Creator)
                .Where(x => x.IsActive && x.Status == 2)
                .ToListAsync();

            if (advertisement == null)
            {
                return null;
            }

            return advertisement.ToAdvertisementDtos();
        }

        public async Task<List<AdvertisementDto>?> GetAdvertismentsByCreator(int creatorId)
        {
            var advertisement = await _linkedInDbContext.Advertisements
                .Include(u => u.AdvertismentProfessionalBranches)
                .Include(u => u.AdvertisementJobTypes)
                .Include(u => u.AdvertismentWorkingLocations)
                .Where(x => x.IsActive)
                .Where(x => x.CreatorId == creatorId)
                .ToListAsync();

            if (advertisement == null)
            {
                return null;
            }

            return advertisement.ToAdvertisementDtos();
        }

        public async Task<List<AdvertisementDto>?> GetAdvertismentsByProfessionalBranches(List<int> professionalBranches)
        {
            var advertisement = await _linkedInDbContext.Advertisements
                .Include(u => u.AdvertismentProfessionalBranches)
                .Include(u => u.AdvertismentProfessionalBranches)
                .Include(u => u.AdvertisementJobTypes)
                .Include(u => u.AdvertismentWorkingLocations)
                .Where(x => x.IsActive).ToListAsync();

            if (advertisement == null)
            {
                return null;
            }

            return advertisement.ToAdvertisementDtos();
        }

        public async Task<List<AdvertisementDto>?> GetAdvertisementsByStatus(byte status)
        {
            var advertisement = await _linkedInDbContext.Advertisements
                .Include(u => u.AdvertismentProfessionalBranches)
                .Include(u => u.AdvertisementJobTypes)
                .Include(u => u.AdvertismentWorkingLocations)
                .Where(x => x.IsActive)
                .Where(x => x.Status == status)
                .ToListAsync();

            if (advertisement == null)
            {
                return null;
            }

            return advertisement.ToAdvertisementDtos();
        }

        public async Task<List<AdvertisementDto>?> GetMyAdvertisements(int currentUserId)
        {
            var advertisement = await _linkedInDbContext.Advertisements
                .Include(u => u.AdvertismentProfessionalBranches)
                .Include(u => u.AdvertisementJobTypes)
                .Include(u => u.AdvertismentWorkingLocations)
                .Where(x => x.IsActive)
                .Where(x => x.CreatorId == currentUserId)
                .ToListAsync();

            if (advertisement == null)
            {
                return null;
            }

            return advertisement.ToAdvertisementDtos();

        }

        public async Task<List<ApplicationNotificationDto>?> GetMyAdvertismentApplicantsAsync(int userId)
        {
            var advertisement = await _linkedInDbContext.Advertisements
                .Include(u => u.AdvertisementApplies)
                .ThenInclude(u => u.User)
                .ThenInclude(u => u.Advertisements)
                .Where(x => x.CreatorId == userId)
                .ToListAsync();

            return advertisement.ToApplicationNotificationDtos();
        }
    }
}
