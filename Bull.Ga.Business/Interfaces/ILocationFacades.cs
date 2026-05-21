using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Data.Models;

namespace Bull.Ga.Business.Interfaces
{
    public interface ILocationFacades
    {
        Task<ResultBase<LocationListResponse>> FindAllLocation(LocationListRequest request);
        Task<ResultBase<Location>> FindByIdLocation(Guid id);
        Task<ResultBase> SaveLocation(LocationInputRequest request);
    }
}
