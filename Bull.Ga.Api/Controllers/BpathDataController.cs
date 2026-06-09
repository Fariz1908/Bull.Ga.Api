using Bull.Ga.Api.Authorization;
using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace Bull.Ga.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BpathDataController : ControllerBase
    {
        private readonly IBpathDataFacades _bpathDataFacades;

        public BpathDataController(IBpathDataFacades bpathDataFacades)
        {
            _bpathDataFacades = bpathDataFacades;
        }


        [HttpPost("FindAllPoDetails")]
        [Authorize]
        public async Task<ActionResult> FindAllPoDetails(PoDetailListRequest request)
        {
            var response = await _bpathDataFacades.FindAllPoDetails(request);

            return Ok(response);

        }

        [HttpPost("FindAllEmployees")]
        [Authorize]
        public async Task<ActionResult> FindAllEmployees(EmployeeListRequest request)
        {
            var response = await _bpathDataFacades.FindAllEmployees(request);

            return Ok(response);

        }
    }
}
