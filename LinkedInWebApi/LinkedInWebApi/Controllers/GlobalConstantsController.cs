using LinkedInWebApi.Application.Handlers;
using LinkedInWebApi.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkedInWebApi.Controllers
{
    /// <summary>
    /// Controller for managing professional branches.
    /// </summary>
    [Route("api/professional-branch/")]
    [ApiController]
    public class GlobalConstantsController : Controller
    {
        private readonly IGlobalConstantsHandler _globalConstantsHandler;

        public GlobalConstantsController(IGlobalConstantsHandler globalConstantsHandler)
        {
            _globalConstantsHandler = globalConstantsHandler;
        }

        /// <summary>
        /// Retrieves a list of professional branch DTOs.
        /// </summary>
        /// <returns>A list of professional branch DTOs.</returns>
        [HttpGet("GetProfessionalBranches")]
        [Authorize]
        public async Task<ActionResult<List<GennericGlobalConstantDto>>> GetProfessionalBranchesAsync()
        {
            try
            {
                return Ok(await _globalConstantsHandler.GetProfessionalBranchAsync());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retrieves a list of job type DTOs.
        /// </summary>
        /// <returns>A list of job type DTOs.</returns>
        [HttpGet("GetJobTypes")]
        [Authorize]
        public async Task<ActionResult<List<GennericGlobalConstantDto>>> GetJobTypesAsync()
        {
            try
            {
                return Ok(await _globalConstantsHandler.GetJobTypeAsync());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retrieves a list of reaction DTOs.
        /// </summary>
        /// <returns>A list of reaction DTOs.</returns>
        [HttpGet("GetReactions")]
        [Authorize]
        public async Task<ActionResult<List<GennericGlobalConstantDto>>> GetReactionsAsync()
        {
            try
            {
                return Ok(await _globalConstantsHandler.GetReactionsAsync());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retrieves a list of working location DTOs.
        /// </summary>
        /// <returns>A list of working location DTOs.</returns>
        [HttpGet("GetWorkingLocations")]
        [Authorize]
        public async Task<ActionResult<List<GennericGlobalConstantDto>>> GetWorkingLocationsAsync()
        {
            try
            {
                return Ok(await _globalConstantsHandler.GetWorkingLocationsAsync());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
