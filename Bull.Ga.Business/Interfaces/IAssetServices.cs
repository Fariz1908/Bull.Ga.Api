using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;

namespace Bull.Ga.Business.Interfaces
{
    public interface IAssetServices
    {
        Task<ResultBase> SaveAsset(AssetInputRequest request);
    }
}
