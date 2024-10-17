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
        private readonly IAdvertisementReadCommands _advertisemenReadCommands;

        public AdvertisementService(IAdvertisementInserCommands advertisemenInsertCommands, IAdvertisementUpdateCommands advertisemenUpdateCommands, IAdvertisementReadCommands advertisemenReadCommands)
        {
            _advertisemenInsertCommands = advertisemenInsertCommands;
            _advertisemenUpdateCommands = advertisemenUpdateCommands;
            _advertisemenReadCommands = advertisemenReadCommands;
        }

        public async Task<List<UserDto>> ApplyApplicantAsync(int id, ClaimsIdentity identity)
        {
            return await _advertisemenReadCommands.ApplyApplicantAsync(id);
        }

        public Task<bool> ApplyForAdvertismentAsync(int applyForAdvertismentDto, ClaimsIdentity identity)
        {
            return _advertisemenInsertCommands.ApplyForAdvertismentAsync(applyForAdvertismentDto, ClaimsIdentityaHelper.GetUserIdAsync(identity));
        }

        /// <summary>
        /// Creates a new advertisement.
        /// </summary>
        /// <param name="advertisementDto">The advertisement data.</param>
        /// <param name="claimsIdentity">The claims identity of the user.</param>
        /// <returns>True if the advertisement is created successfully, otherwise false.</returns>
        public async Task<bool> CreateAdvertisement(CreateAdvertisementDto advertisementDto, ClaimsIdentity claimsIdentity)
        {
            var createResult = await _advertisemenInsertCommands.CreateAdvertisement(advertisementDto, ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity));

            if (!createResult)
            {
                throw ErrorException.UnexpectedBehaviorException;
            }

            return true;
        }

        /// <summary>
        /// Deletes an advertisement.
        /// </summary>
        /// <param name="id">The ID of the advertisement to delete.</param>
        /// <param name="claimsIdentity">The claims identity of the user.</param>
        /// <returns>True if the advertisement is deleted successfully, otherwise false.</returns>
        public async Task<bool> DeleteAdvertisment(int id, ClaimsIdentity claimsIdentity)
        {
            var updateResult = await _advertisemenUpdateCommands.DeleteAdvertisement(id, ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity));

            if (!updateResult)
            {
                throw ErrorException.UnexpectedBehaviorException;
            }

            return true;
        }

        /// <summary>
        /// Retrieves an advertisement by ID.
        /// </summary>
        /// <param name="id">The ID of the advertisement to retrieve.</param>
        /// <param name="claimsIdentity">The claims identity of the user.</param>
        /// <returns>The advertisement if found, otherwise null.</returns>
        public async Task<AdvertisementDto?> GetAdvertisment(int id, ClaimsIdentity claimsIdentity)
        {
            return await _advertisemenReadCommands.GetAdvertisment(id);
        }

        /// <summary>
        /// Retrieves a list of all advertisements.
        /// </summary>
        /// <param name="claimsIdentity">The claims identity of the user.</param>
        /// <returns>A list of advertisements.</returns>
        public async Task<List<AdvertisementDto>?> GetAdvertisments(ClaimsIdentity claimsIdentity)
        {
            var advertisments = await _advertisemenReadCommands.GetAdvertisments();
            return advertisments?.OrderByDescending(x => x.TimesViewed).ToList();
        }

        /// <summary>
        /// Retrieves a list of advertisements by professional branches.
        /// </summary>
        /// <param name="professionalBranches">The list of professional branches.</param>
        /// <returns>A list of advertisements.</returns>
        public Task<List<AdvertisementDto>?> GetAdvertismentsByProfessionalBranches(List<int> professionalBranches)
        {
            return _advertisemenReadCommands.GetAdvertismentsByProfessionalBranches(professionalBranches);
        }

        /// <summary>
        /// Retrieves a list of advertisements by status.
        /// </summary>
        /// <param name="status">The status of the advertisements.</param>
        /// <param name="claimsIdentity">The claims identity of the user.</param>
        /// <returns>A list of advertisements.</returns>
        public Task<List<AdvertisementDto>?> GetAdvertismentsOfUserByStatusAsync(byte status, ClaimsIdentity claimsIdentity)
        {
            return _advertisemenReadCommands.GetAdvertisementsByStatus(status);
        }

        public async Task<List<ApplicationNotificationDto>?> GetApplyApplicationNotificationAsync(ClaimsIdentity identity)
        {
            return await _advertisemenReadCommands.GetMyAdvertismentApplicantsAsync(ClaimsIdentityaHelper.GetUserIdAsync(identity));
        }

        public Task<List<AdvertisementDto>?> GetMyAdvertisementAsync(ClaimsIdentity claimsIdentity)
        {
            return _advertisemenReadCommands.GetMyAdvertisements(ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity));
        }

        /// <summary>
        /// Updates an advertisement.
        /// </summary>
        /// <param name="advertisementDto">The updated advertisement data.</param>
        /// <param name="claimsIdentity">The claims identity of the user.</param>
        /// <returns>True if the advertisement is updated successfully, otherwise false.</returns>
        public async Task<bool> UpdateAdvertismentAsync(UpdateAdvertisementDto advertisementDto, ClaimsIdentity claimsIdentity)
        {
            var curentUserId = ClaimsIdentityaHelper.GetUserIdAsync(claimsIdentity);
            var updateResult = await _advertisemenUpdateCommands.UpdateAdvertisementAsync(advertisementDto, curentUserId);

            if (!updateResult)
            {
                throw ErrorException.UnexpectedBehaviorException;
            }

            return true;
        }

    }
}
