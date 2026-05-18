using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;

namespace Bull.Ga.Business.Interfaces
{
    public interface IAssetCategoryServices
    {
        Task<AssetCategoryListResponse> FindAllAssetCategory(AssetCategoryListRequest request);
        Task<AssetCategoryDto> FindByIdAssetCategory(int id);
        Task<ResultBase> SaveAssetCategory(AssetCategoryInputRequest request);
    }
}
