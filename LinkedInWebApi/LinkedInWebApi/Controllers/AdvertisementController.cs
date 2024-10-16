using LinkedInWebApi.Application.Handlers;
using LinkedInWebApi.Core;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinkedInWebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementHandler _advertisementHandler;
        private readonly ClaimsIdentity _identity;

        public AdvertisementController(IAdvertisementHandler advertisementHandler, IHttpContextAccessor httpContextAccessor)
        {
            _advertisementHandler = advertisementHandler;
            _identity = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        }

        /// <summary>
        /// Creates a new advertisement.
        /// </summary>
        /// <param name="createAdvertisementDto">The data for creating the advertisement.</param>
        /// <returns>The created advertisement.</returns>
        [HttpPost("CreateAdvertisement")]
        public async Task<ActionResult<AdvertisementDto>> CreateAdvertisement([FromBody] CreateAdvertisementDto createAdvertisementDto)
        {
            try
            {
                return Ok(await _advertisementHandler.CreateAdvertisementAsync(createAdvertisementDto, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Updates an existing advertisement.
        /// </summary>
        /// <param name="advertisementDto">The data for updating the advertisement.</param>
        /// <returns>True if the advertisement was updated successfully, otherwise false.</returns>
        [HttpPost("UpdateAdvertisement")]
        public async Task<ActionResult<bool>> UpdateAdvertisement([FromBody] UpdateAdvertisementDto advertisementDto)
        {
            try
            {
                return Ok(await _advertisementHandler.UpdateAdvertismentAsync(advertisementDto, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Deletes an advertisement by its ID.
        /// </summary>
        /// <param name="id">The ID of the advertisement to delete.</param>
        /// <returns>True if the advertisement was deleted successfully, otherwise false.</returns>
        [HttpPost("DeleteAdvertisement/{id}")]
        public async Task<ActionResult<bool>> DeleteAdvertisement(int id)
        {
            try
            {
                return Ok(await _advertisementHandler.DeleteAdvertisment(id, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets an advertisement by its ID.
        /// </summary>
        /// <param name="id">The ID of the advertisement to get.</param>
        /// <returns>The advertisement with the specified ID.</returns>
        [HttpGet("GetAdvertisement/{id}")]
        public async Task<ActionResult<AdvertisementDto>> GetAdvertisement(int id)
        {
            try
            {
                return Ok(await _advertisementHandler.GetAdvertismentAsync(id, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets all advertisements.
        /// </summary>
        /// <returns>A list of all advertisements.</returns>
        [HttpGet("GetAdvertisements")]
        public async Task<ActionResult<List<AdvertisementDto>>> GetAdvertisements()
        {
            try
            {
                return Ok(await _advertisementHandler.GetAdvertismentsAsync(_identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets advertisements by professional branches.
        /// </summary>
        /// <param name="professionalBranches">The list of professional branches.</param>
        /// <returns>A list of advertisements filtered by professional branches.</returns>
        [HttpGet("GetAdvertisementsByProfessionalBranches")]
        public async Task<ActionResult<List<AdvertisementDto>>> GetAdvertisementsByProfessionalBranches([FromBody] List<int> professionalBranches)
        {
            try
            {
                return Ok(await _advertisementHandler.GetAdvertismentsByProfessionalBranchesAsync(professionalBranches));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets advertisements of a user by status.
        /// </summary>
        /// <param name="status">The status of the advertisements.</param>
        /// <returns>A list of advertisements of the user filtered by status.</returns>
        [HttpGet("GetAdvertisementsOfUserByStatus/{status}")]
        public async Task<ActionResult<List<AdvertisementDto>>> GetAdvertisementsOfUserByStatus(byte status)
        {
            try
            {
                return Ok(await _advertisementHandler.GetAdvertismentsOfUserByStatusAsync(status, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetMyAdvertisements")]
        public async Task<ActionResult<List<AdvertisementDto>>> GetMyAdvertisements()
        {
            try
            {
                return Ok(await _advertisementHandler.GetMyAdvertisementAsync(_identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("ApplyForAdvertisment")]
        public async Task<ActionResult<bool>> ApplyForAdvertisment([FromBody] int advertismentId)
        {
            try
            {
                return Ok(await _advertisementHandler.ApplyForAdvertismentAsync(advertismentId, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("ApplyApplicant/{id}")]
        public async Task<ActionResult<List<UserDto>>> ApproveApplicant(int id)
        {
            try
            {
                return Ok(await _advertisementHandler.ApplyApplicantAsync(id, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
