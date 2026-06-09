using Bull.Ga.Common.DtoModels;

namespace Bull.Ga.Business.Interfaces
{
    public interface IBpathDataServices
    {
        Task<PoDetailListResponse> FindAllPoDetails(PoDetailListRequest request);
        Task<EmployeeListResponse> FindAllEmployees(EmployeeListRequest request);
    }
}
