using Bull.Ga.Api.Authorization;
using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace Bull.Ga.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyFacades _companyFacades;
        
        public CompanyController(ICompanyFacades companyFacades)
        {
            _companyFacades = companyFacades;
        }

        [HttpPost("FindAll")]
        [Authorize]
        public async Task<ActionResult> FindAllCompany(CompanyListRequest request)
        {
            var response = await _companyFacades.FindAllCompany(request);

            return Ok(response);

        }

        [HttpGet("FindById")]
        [Authorize]
        public async Task<ActionResult> FindByIdCompany(Guid id)
        {
            var response = await _companyFacades.FindByIdCompany(id);

            return Ok(response);

        }

        [HttpPost("Save")]
        [Authorize]
        public async Task<ActionResult> SaveCompany(CompanyInputRequest request)
        {
            var response = await _companyFacades.SaveCompany(request);

            return Ok(response);

        }
    }
}
