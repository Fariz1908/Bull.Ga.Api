using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.Constants;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Data.Models;

namespace Bull.Ga.Business.Facades
{
    public class DepartmentFacades : IDepartmentFacades
    {
        private readonly IDepartmentServices _departmentServices;

        public DepartmentFacades(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        public async Task<ResultBase<DepartmentListResponse>> FindAllDepartment(DepartmentListRequest request)
        {
            var result = await _departmentServices.FindAllDepartment(request);

            if (result != null)
            {
                return new ResultBase<DepartmentListResponse>
                {
                    Success = true,
                    Message = "Success",
                    Model = result
                };
            }

            var errorResponse = new ResultBase<DepartmentListResponse>
            {
                Success = false,
                Message = MessageConstants.S_DATA_NOT_FOUND,
                Model = result
            };

            return errorResponse;
        }

        public async Task<ResultBase<Department>> FindByIdDepartment(Guid id)
        {
            var result = await _departmentServices.FindByIdDepartment(id);

            if (result != null)
            {
                return new ResultBase<Department>
                {
                    Success = true,
                    Message = "Success",
                    Model = result
                };
            }

            var errorResponse = new ResultBase<Department>
            {
                Success = false,
                Message = MessageConstants.S_DATA_NOT_FOUND,
                Model = result
            };

            return errorResponse;
        }

        public async Task<ResultBase> SaveDepartment(DepartmentInputRequest request)
        {
            var result = await _departmentServices.SaveDepartment(request);

            return result;
        }
    }
}
