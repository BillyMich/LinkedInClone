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

        /// <summary>
        /// Creates a new advertisement.
        /// </summary>
        /// <param name="advertisementDto">The advertisement data.</param>
        /// <param name="claimsIdentity">The claims identity of the user.</param>
        /// <returns>True if the advertisement is created successfully, otherwise false.</returns>
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

        /// <summary>
        /// Deletes an advertisement.
        /// </summary>
        /// <param name="id">The ID of the advertisement to delete.</param>
        /// <param name="claimsIdentity">The claims identity of the user.</param>
        /// <returns>True if the advertisement is deleted successfully, otherwise false.</returns>
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
        public Task<List<AdvertisementDto>> GetAdvertisments(ClaimsIdentity claimsIdentity)
        {
            return _advertisemenReadCommands.GetAdvertisments();
        }

        /// <summary>
        /// Retrieves a list of advertisements by professional branches.
        /// </summary>
        /// <param name="professionalBranches">The list of professional branches.</param>
        /// <returns>A list of advertisements.</returns>
        public Task<List<AdvertisementDto>> GetAdvertismentsByProfessionalBranches(List<int> professionalBranches)
        {
            return _advertisemenReadCommands.GetAdvertismentsByProfessionalBranches(professionalBranches);
        }

        /// <summary>
        /// Retrieves a list of advertisements by status.
        /// </summary>
        /// <param name="status">The status of the advertisements.</param>
        /// <param name="claimsIdentity">The claims identity of the user.</param>
        /// <returns>A list of advertisements.</returns>
        public Task<List<AdvertisementDto>> GetAdvertismentsOfUserByStatusAsync(byte status, ClaimsIdentity claimsIdentity)
        {
            return _advertisemenReadCommands.GetAdvertismentsByStatus(status);
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
            var result = await _advertisemenUpdateCommands.UpdateAdvertisementAsync(advertisementDto, curentUserId);

            if (!result)
            {
                throw ErrorException.UnexpectedBehaviorException;
            }

            return true;
        }
    }
}
