using LinkedInWebApi.Application.Services;
using LinkedInWebApi.Core;
using System.Security.Claims;

namespace LinkedInWebApi.Application.Handlers
{
    /// <summary>
    /// Handles advertisement-related operations.
    /// </summary>
    public class AdvertisementHandler : IAdvertisementHandler
    {
        private readonly IAdvertisementService _advertisementService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvertisementHandler"/> class.
        /// </summary>
        /// <param name="advertisementService">The advertisement service.</param>
        public AdvertisementHandler(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        /// <summary>
        /// Creates a new advertisement asynchronously.
        /// </summary>
        /// <param name="advertisementDto">The advertisement DTO.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <returns>A task representing the asynchronous operation, returning true if the advertisement is created successfully.</returns>
        public Task<bool> CreateAdvertisementAsync(CreateAdvertisementDto advertisementDto, ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.CreateAdvertisement(advertisementDto, claimsIdentity);
        }

        /// <summary>
        /// Deletes an advertisement asynchronously.
        /// </summary>
        /// <param name="id">The advertisement ID.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <returns>A task representing the asynchronous operation, returning true if the advertisement is deleted successfully.</returns>
        public Task<bool> DeleteAdvertisment(int id, ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.DeleteAdvertisment(id, claimsIdentity);
        }

        /// <summary>
        /// Retrieves an advertisement asynchronously.
        /// </summary>
        /// <param name="id">The advertisement ID.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <returns>A task representing the asynchronous operation, returning the advertisement DTO if found, otherwise null.</returns>
        public Task<AdvertisementDto?> GetAdvertismentAsync(int id, ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.GetAdvertisment(id, claimsIdentity);
        }

        /// <summary>
        /// Retrieves a list of advertisements asynchronously.
        /// </summary>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <returns>A task representing the asynchronous operation, returning a list of advertisement DTOs.</returns>
        public Task<List<AdvertisementDto>> GetAdvertismentsAsync(ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.GetAdvertisments(claimsIdentity);
        }

        /// <summary>
        /// Retrieves a list of advertisements by professional branches asynchronously.
        /// </summary>
        /// <param name="professionalBranches">The list of professional branches.</param>
        /// <returns>A task representing the asynchronous operation, returning a list of advertisement DTOs.</returns>
        public Task<List<AdvertisementDto>> GetAdvertismentsByProfessionalBranchesAsync(List<int> professionalBranches)
        {
            return _advertisementService.GetAdvertismentsByProfessionalBranches(professionalBranches);
        }

        /// <summary>
        /// Retrieves a list of advertisements of a user by status asynchronously.
        /// </summary>
        /// <param name="status">The advertisement status.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <returns>A task representing the asynchronous operation, returning a list of advertisement DTOs.</returns>
        public Task<List<AdvertisementDto>> GetAdvertismentsOfUserByStatusAsync(byte status, ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.GetAdvertismentsOfUserByStatusAsync(status, claimsIdentity);
        }

        public async Task<List<AdvertisementDto>> GetMyAdvertisementAsync(ClaimsIdentity identity)
        {
            return await _advertisementService.GetMyAdvertisementAsync(identity);
        }

        /// <summary>
        /// Updates an advertisement asynchronously.
        /// </summary>
        /// <param name="advertisementDto">The updated advertisement DTO.</param>
        /// <param name="claimsIdentity">The claims identity.</param>
        /// <returns>A task representing the asynchronous operation, returning true if the advertisement is updated successfully.</returns>
        public Task<bool> UpdateAdvertismentAsync(UpdateAdvertisementDto advertisementDto, ClaimsIdentity claimsIdentity)
        {
            return _advertisementService.UpdateAdvertismentAsync(advertisementDto, claimsIdentity);
        }
    }
}
