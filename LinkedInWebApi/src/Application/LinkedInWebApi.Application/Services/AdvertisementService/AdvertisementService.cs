using LinkedInWebApi.Core;
using LinkedInWebApi.Core.ExceptionHandler;
using LinkedInWebApi.Core.Helpers;
using LinkedInWebApi.Reposirotry.Commands;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Services
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IAdvertisementInserCommands _advertisemenInsertCommands;
        private readonly IAdvertisementUpdateCommands _advertisemenUpdateCommands;
        private readonly IAdvertisemenReadCommands _advertisemenReadCommands;

        public AdvertisementService(IAdvertisementInserCommands advertisemenInsertCommands, IAdvertisementUpdateCommands advertisemenUpdateCommands, IAdvertisemenReadCommands advertisemenReadCommands)
        {
            _advertisemenInsertCommands = advertisemenInsertCommands;
            _advertisemenUpdateCommands = advertisemenUpdateCommands;
            _advertisemenReadCommands = advertisemenReadCommands;
        }

        public async Task<bool> CreateAdvertisement(CreateAdvertisementDto advertisementDto, ClaimsIdentity claimsIdentity)
        {

            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);
            var result = await _advertisemenInsertCommands.CreateAdvertisement(advertisementDto, curentUserId);

            if (!result)
            {
                throw ErrorException.UnexpectedBehaviorException;
            }

            return true;

        }

        public async Task<bool> DeleteAdvertisment(int id, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);
            var result = await _advertisemenUpdateCommands.DeleteAdvertisement(id, curentUserId);

            if (!result)
            {
                throw ErrorException.UnexpectedBehaviorException;
            }
            return true;
        }

        public async Task<AdvertisementDto?> GetAdvertisment(int id, ClaimsIdentity claimsIdentity)
        {
            return await _advertisemenReadCommands.GetAdvertisment(id);
        }

        public Task<List<AdvertisementDto>> GetAdvertisments(ClaimsIdentity claimsIdentity)
        {
            return _advertisemenReadCommands.GetAdvertisments();
        }

        public Task<List<AdvertisementDto>> GetAdvertismentsByProfessionalBranches(List<int> professionalBranches)
        {
            return _advertisemenReadCommands.GetAdvertismentsByProfessionalBranches(professionalBranches);
        }

        public Task<List<AdvertisementDto>> GetAdvertismentsOfUserByStatusAsync(byte status, ClaimsIdentity claimsIdentity)
        {
            return _advertisemenReadCommands.GetAdvertismentsByStatus(status);
        }

        public async Task<bool> UpdateAdvertismentAsync(UpdateAdvertisementDto advertisementDto, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);
            var result = await _advertisemenUpdateCommands.UpdateAdvertisementAsync(advertisementDto, curentUserId);

            if (!result)
            {
                throw ErrorException.UnexpectedBehaviorException;
            }
            return true;
        }
    }
}
