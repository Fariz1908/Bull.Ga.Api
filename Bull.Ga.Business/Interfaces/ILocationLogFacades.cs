using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;

namespace Bull.Ga.Business.Interfaces
{
    public interface ILocationLogFacades
    {
        Task<ResultBase<LocationLogListResponse>> FindByFidAssetLocationLog(LocationLogListRequest request);
        Task<ResultBase> SaveLocationLog(LocationLogInputRequest request);
    }
}
