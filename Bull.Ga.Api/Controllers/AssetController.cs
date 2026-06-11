using Bull.Ga.Api.Authorization;
using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace Bull.Ga.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetFacades _assetFacades;

        public AssetController(IAssetFacades assetFacades)
        {
            _assetFacades = assetFacades;
        }

        [HttpPost("Save")]
        [Authorize]
        public async Task<ActionResult> FindAllAssetCategory(AssetInputRequest request)
        {
            var response = await _assetFacades.SaveAsset(request);

            return Ok(response);

        }
    }
}
