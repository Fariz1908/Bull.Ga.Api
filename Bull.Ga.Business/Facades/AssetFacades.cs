using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;

namespace Bull.Ga.Business.Facades
{
    public class AssetFacades : IAssetFacades
    {
        private readonly IAssetServices _assetServices;

        public AssetFacades(IAssetServices assetServices)
        {
            _assetServices = assetServices;
        }

        public async Task<ResultBase> SaveAsset(AssetInputRequest request)
        {
            var result = await _assetServices.SaveAsset(request);

            return result;
        }
    }
}
