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

        public AdvertisementController(IAdvertisementHandler advertisementHandler, ClaimsIdentity identity)
        {
            _advertisementHandler = advertisementHandler;
            _identity = identity;
        }

        [HttpPost("CreateAdvertisement")]
        public async Task<ActionResult<AdvertisementDto>> CreateAdvertisement([FromBody] CreateAdvertisementDto createAdvertisementDto)
        {
            try
            {
                return Ok(await _advertisementHandler.CreateAdvertisement(createAdvertisementDto, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("UpdateAdvertisement")]
        public async Task<ActionResult<bool>> UpdateAdvertisement([FromBody] AdvertisementDto advertisementDto)
        {
            try
            {
                return Ok(await _advertisementHandler.UpdateAdvertisment(advertisementDto, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

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

        [HttpGet("GetAdvertisement/{id}")]
        public async Task<ActionResult<AdvertisementDto>> GetAdvertisement(int id)
        {
            try
            {
                return Ok(await _advertisementHandler.GetAdvertisment(id, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAdvertisements")]
        public async Task<ActionResult<List<AdvertisementDto>>> GetAdvertisements()
        {
            try
            {
                return Ok(await _advertisementHandler.GetAdvertisments(_identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAdvertisementsByProfessionalBranches")]
        public async Task<ActionResult<List<AdvertisementDto>>> GetAdvertisementsByProfessionalBranches([FromBody] List<int> professionalBranches)
        {
            try
            {
                return Ok(await _advertisementHandler.GetAdvertismentsByProfessionalBranches(professionalBranches));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAdvertisementsOfUserByStatus/{status}")]
        public async Task<ActionResult<List<AdvertisementDto>>> GetAdvertisementsOfUserByStatus(byte status)
        {
            try
            {
                return Ok(await _advertisementHandler.GetAdvertismentsOfUserByStatus(status, _identity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
