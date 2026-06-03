using Bull.Ga.Api.Authorization;
using Bull.Ga.Business.Interfaces;
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

        [HttpGet("AssetCategories")]
        [Authorize]
        public async Task<ActionResult> AssetCategories(string? filter)
        {
            var response = await _dropdownFacades.AssetCatgories(filter);

            return Ok(response);

        }

        [HttpGet("Companies")]
        [Authorize]
        public async Task<ActionResult> Companies(string? filter)
        {
            var response = await _dropdownFacades.Companies(filter);

            return Ok(response);
        }

        [HttpGet("Departments")]
        [Authorize]
        public async Task<ActionResult> Departments(string? filter)
        {
            var response = await _dropdownFacades.Departments(filter);

            return Ok(response);
        }

        [HttpGet("DepreciationMethods")]
        [Authorize]
        public async Task<ActionResult> DepreciationMethods(string? filter)
        {
            var response = await _dropdownFacades.DepreciationMethods(filter);

            return Ok(response);
        }

        [HttpGet("Items")]
        [Authorize]
        public async Task<ActionResult> Items(string? filter)
        {
            var response = await _dropdownFacades.Items(filter);

            return Ok(response);
        }

        [HttpGet("Locations")]
        [Authorize]
        public async Task<ActionResult> Locations(string? filter)
        {
            var response = await _dropdownFacades.Locations(filter);

            return Ok(response);
        }
    }
}
