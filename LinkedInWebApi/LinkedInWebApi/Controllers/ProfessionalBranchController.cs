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
    public class ProfessionalBranchController : Controller
    {
        private readonly IProfessionalBranchHandler _professionalBranchHandler;

        public ProfessionalBranchController(IProfessionalBranchHandler professionalBranchHandler)
        {
            _professionalBranchHandler = professionalBranchHandler;
        }

        /// <summary>
        /// Retrieves a list of professional branch DTOs.
        /// </summary>
        /// <returns>A list of professional branch DTOs.</returns>
        [HttpGet("GetProfessionalBranch")]
        [Authorize]
        public async Task<ActionResult<List<ProfessionalBranchDto>>> GetProfessionalBranchDtos()
        {
            try
            {
                return Ok(await _professionalBranchHandler.GetProfessionalBranchDtos());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
