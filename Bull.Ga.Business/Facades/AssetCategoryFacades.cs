using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.Constants;
using Bull.Ga.Common.DtoModels;

namespace Bull.Ga.Business.Facades
{
    public class AssetCategoryFacades : IAssetCategoryFacades
    {
        private readonly IAssetCategoryServices _assetCategoryServices;

        public AssetCategoryFacades(IAssetCategoryServices assetCategoryServices)
        {
            _assetCategoryServices = assetCategoryServices;
        }

        public async Task<ResultBase<AssetCategoryListResponse>> FindAllAssetCategory(AssetCategoryListRequest request)
        {
            var result = await _assetCategoryServices.FindAllAssetCategory(request);

            if (result != null)
            {
                return new ResultBase<AssetCategoryListResponse>
                {
                    Success = true,
                    Message = "Success",
                    Model = result
                };
            }

            var errorResponse = new ResultBase<AssetCategoryListResponse>
            {
                Success = false,
                Message = MessageConstants.S_DATA_NOT_FOUND,
                Model = result
            };

            return errorResponse;
        }

        public async Task<ResultBase<AssetCategoryDto>> FindByIdAssetCategory(int id)
        {
            var result = await _assetCategoryServices.FindByIdAssetCategory(id);

            if (result != null)
            {
                return new ResultBase<AssetCategoryDto>
                {
                    Success = true,
                    Message = "Success",
                    Model = result
                };
            }

            var errorResponse = new ResultBase<AssetCategoryDto>
            {
                Success = false,
                Message = MessageConstants.S_DATA_NOT_FOUND,
                Model = result
            };

            return errorResponse;
        }

        public async Task<ResultBase> SaveAssetCategory(AssetCategoryInputRequest request)
        {
            var result = await _assetCategoryServices.SaveAssetCategory(request);

            return result;
        }
    }
}
