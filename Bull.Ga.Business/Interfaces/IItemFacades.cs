using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;

namespace Bull.Ga.Business.Interfaces
{
    public interface IItemFacades
    {
        Task<ResultBase<ItemListResponse>> FindAllItems(ItemListRequest request);
        Task<ResultBase<ItemDto>> FindItemById(Guid id);
        Task<ResultBase> SaveItem(ItemInputRequest request);
    }
}
