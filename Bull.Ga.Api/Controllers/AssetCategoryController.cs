using Bull.Ga.Api.Authorization;
using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace Bull.Ga.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AssetCategoryController : ControllerBase
    {
        private readonly IAssetCategoryFacades _assetCategoryFacades;

        public AssetCategoryController(IAssetCategoryFacades assetCategoryFacades)
        {
            _assetCategoryFacades = assetCategoryFacades;
        }

        [HttpPost("FindAll")]
        [Authorize]
        public async Task<ActionResult> FindAllAssetCategory(AssetCategoryListRequest request)
        {
            var response = await _assetCategoryFacades.FindAllAssetCategory(request);

            return Ok(response);

        }

        [HttpGet("FindById")]
        [Authorize]
        public async Task<ActionResult> FindByIdAssetCategory(int id)
        {
            var response = await _assetCategoryFacades.FindByIdAssetCategory(id);

            return Ok(response);

        }

        [HttpPost("Save")]
        [Authorize]
        public async Task<ActionResult> SaveAssetCategory(AssetCategoryInputRequest request)
        {
            var response = await _assetCategoryFacades.SaveAssetCategory(request);

            return Ok(response);

        }
    }
}
