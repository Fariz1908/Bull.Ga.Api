using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;

namespace Bull.Ga.Business.Interfaces
{
    public interface IItemServices
    {
        Task<ItemListResponse> FindAllItems(ItemListRequest request);
        Task<ItemDto> FindItemById(Guid id);
        Task<ResultBase> SaveItem(ItemInputRequest request);
    }
}
