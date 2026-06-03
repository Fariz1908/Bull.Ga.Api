using Bull.Ga.Api.Authorization;
using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace Bull.Ga.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemFacades _itemFacades;

        public ItemController(IItemFacades itemFacades)
        {
            _itemFacades = itemFacades;
        }

        [HttpPost("FindAll")]
        [Authorize]
        public async Task<ActionResult> FindAllItems(ItemListRequest request)
        {
            var response = await _itemFacades.FindAllItems(request);

            return Ok(response);

        }

        [HttpGet("FindById")]
        [Authorize]
        public async Task<ActionResult> FindItemById(Guid id)
        {
            var response = await _itemFacades.FindItemById(id);

            return Ok(response);

        }

        [HttpPost("Save")]
        [Authorize]
        public async Task<ActionResult> SaveItem(ItemInputRequest request)
        {
            var response = await _itemFacades.SaveItem(request);

            return Ok(response);

        }
    }
}
