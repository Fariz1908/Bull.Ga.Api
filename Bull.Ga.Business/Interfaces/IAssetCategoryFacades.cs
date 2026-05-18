using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;

namespace Bull.Ga.Business.Interfaces
{
    public interface IAssetCategoryFacades
    {
        Task<ResultBase<AssetCategoryListResponse>> FindAllAssetCategory(AssetCategoryListRequest request);
        Task<ResultBase<AssetCategoryDto>> FindByIdAssetCategory(int id);
        Task<ResultBase> SaveAssetCategory(AssetCategoryInputRequest request);
    }
}
