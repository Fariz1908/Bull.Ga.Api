using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Data.Models;

namespace Bull.Ga.Business.Interfaces
{
    public interface IDepartmentServices
    {
        Task<DepartmentListResponse> FindAllDepartment(DepartmentListRequest request);
        Task<Department> FindByIdDepartment(Guid id);
        Task<ResultBase> SaveDepartment(DepartmentInputRequest request);
    }
}
