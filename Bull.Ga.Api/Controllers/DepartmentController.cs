using Bull.Ga.Api.Authorization;
using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace Bull.Ga.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentFacades _departmentFacades;

        public DepartmentController(IDepartmentFacades departmentFacades)
        {
            _departmentFacades = departmentFacades;
        }

        [HttpPost("FindAll")]
        [Authorize]
        public async Task<ActionResult> FindAllDepartment(DepartmentListRequest request)
        {
            var response = await _departmentFacades.FindAllDepartment(request);

            return Ok(response);

        }

        [HttpGet("FindById")]
        [Authorize]
        public async Task<ActionResult> FindByIdDepartment(Guid id)
        {
            var response = await _departmentFacades.FindByIdDepartment(id);

            return Ok(response);

        }

        [HttpPost("Save")]
        [Authorize]
        public async Task<ActionResult> SaveDepartment(DepartmentInputRequest request)
        {
            var response = await _departmentFacades.SaveDepartment(request);

            return Ok(response);

        }
    }
}
