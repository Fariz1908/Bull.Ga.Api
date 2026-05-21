using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Data.Models;

namespace Bull.Ga.Business.Interfaces
{
    public interface ILocationServices
    {
        Task<LocationListResponse> FindAllLocation(LocationListRequest request);
        Task<Location> FindByIdLocation(Guid id);
        Task<ResultBase> SaveLocation(LocationInputRequest request);
    }
}
