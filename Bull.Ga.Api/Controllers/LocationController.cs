using Bull.Ga.Api.Authorization;
using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace Bull.Ga.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationFacades _locationFacades;

        public LocationController(ILocationFacades locationFacades)
        {
            _locationFacades = locationFacades;
        }

        [HttpPost("FindAll")]
        [Authorize]
        public async Task<ActionResult> FindAllLocation(LocationListRequest request)
        {
            var response = await _locationFacades.FindAllLocation(request);

            return Ok(response);

        }

        [HttpGet("FindById")]
        [Authorize]
        public async Task<ActionResult> FindByIdLocation(Guid id)
        {
            var response = await _locationFacades.FindByIdLocation(id);

            return Ok(response);

        }

        [HttpPost("Save")]
        [Authorize]
        public async Task<ActionResult> SaveLocation(LocationInputRequest request)
        {
            var response = await _locationFacades.SaveLocation(request);

            return Ok(response);

        } 
    }
}
