using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;

namespace Bull.Ga.Business.Facades
{
    public class ItemFacades : IItemFacades
    {
        private readonly IItemServices _itemServices;

        public ItemFacades(IItemServices itemServices)
        {
            _itemServices = itemServices;
        }

        public async Task<ResultBase<ItemListResponse>> FindAllItems(ItemListRequest request)
        {
            var result = await _itemServices.FindAllItems(request);

            if (result != null)
            {
                return new ResultBase<ItemListResponse>
                {
                    Success = true,
                    Message = "Sukses",
                    Model = result
                };
            }

            var errorResponse = new ResultBase<ItemListResponse>
            {
                Success = false,
                Message = "Data tidak ditemukan",
                Model = result
            };

            return errorResponse;
        }

        public async Task<ResultBase<ItemDto>> FindItemById(Guid id)
        {
            var result = await _itemServices.FindItemById(id);

            if (result != null)
            {
                return new ResultBase<ItemDto>
                {
                    Success = true,
                    Message = "Sukses",
                    Model = result
                };
            }

            var errorResponse = new ResultBase<ItemDto>
            {
                Success = false,
                Message = "Data tidak ditemukan",
                Model = result
            };

            return errorResponse;
        }

        public async Task<ResultBase> SaveItem(ItemInputRequest request)
        {
            var result = await _itemServices.SaveItem(request);

            return result;
        }
    }
}
