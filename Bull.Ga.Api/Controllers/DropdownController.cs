using Bull.Ga.Api.Authorization;
using Bull.Ga.Business.Facades;
using Bull.Ga.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bull.Ga.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DropdownController : ControllerBase
    {
        public readonly IDropdownFacades _dropdownFacades;

        public DropdownController(IDropdownFacades dropdownFacades)
        {
            _dropdownFacades = dropdownFacades;
        }

        [HttpGet("DepreciationMethods")]
        [Authorize]
        public async Task<ActionResult> DepreciationMethods(string? filter)
        {
            var response = await _dropdownFacades.DepreciationMethods(filter);

            return Ok(response);
        }
    }
}
