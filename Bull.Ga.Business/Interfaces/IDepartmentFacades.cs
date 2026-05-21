using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Data.Models;

namespace Bull.Ga.Business.Interfaces
{
    public interface IDepartmentFacades
    {
        Task<ResultBase<DepartmentListResponse>> FindAllDepartment(DepartmentListRequest request);
        Task<ResultBase<Department>> FindByIdDepartment(Guid id);
        Task<ResultBase> SaveDepartment(DepartmentInputRequest request);
    }
}
