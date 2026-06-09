using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;

namespace Bull.Ga.Business.Interfaces
{
    public interface IBpathDataFacades
    {
        Task<ResultBase<PoDetailListResponse>> FindAllPoDetails(PoDetailListRequest request);
        Task<ResultBase<EmployeeListResponse>> FindAllEmployees(EmployeeListRequest request);
    }
}
