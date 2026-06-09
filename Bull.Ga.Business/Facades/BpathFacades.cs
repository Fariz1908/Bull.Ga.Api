using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.Constants;
using Bull.Ga.Common.DtoModels;

namespace Bull.Ga.Business.Facades
{
    public class BpathFacades : IBpathDataFacades

    {
        private readonly IBpathDataServices _bpathDataServices;

        public BpathFacades(IBpathDataServices bpathDataServices)
        {
            _bpathDataServices = bpathDataServices;
        }

        public async Task<ResultBase<EmployeeListResponse>> FindAllEmployees(EmployeeListRequest request)
        {
            var result = await _bpathDataServices.FindAllEmployees(request);

            if (result != null)
            {
                return new ResultBase<EmployeeListResponse>
                {
                    Success = true,
                    Message = "Success",
                    Model = result
                };
            }

            var errorResponse = new ResultBase<EmployeeListResponse>
            {
                Success = false,
                Message = MessageConstants.S_DATA_NOT_FOUND,
                Model = result
            };

            return errorResponse;
        }

        public async Task<ResultBase<PoDetailListResponse>> FindAllPoDetails(PoDetailListRequest request)
        {
            var result = await _bpathDataServices.FindAllPoDetails(request);

            if (result != null)
            {
                return new ResultBase<PoDetailListResponse>
                {
                    Success = true,
                    Message = "Success",
                    Model = result
                };
            }

            var errorResponse = new ResultBase<PoDetailListResponse>
            {
                Success = false,
                Message = MessageConstants.S_DATA_NOT_FOUND,
                Model = result
            };

            return errorResponse;
        }
    }
}
