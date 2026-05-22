using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Data.Models;

namespace Bull.Ga.Business.Facades
{
    public class CompanyFacades : ICompanyFacades
    {
        private readonly ICompanyServices _companyServices;

        public CompanyFacades(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }

        public async Task<ResultBase<CompanyListResponse>> FindAllCompany(CompanyListRequest request)
        {
            var result = await _companyServices.FindAllCompany(request);

            if (result != null)
            {
                return new ResultBase<CompanyListResponse>
                {
                    Success = true,
                    Message = "Sukses",
                    Model = result
                };
            }

            var errorResponse = new ResultBase<CompanyListResponse>
            {
                Success = false,
                Message = "Data tidak ditemukan",
                Model = result
            };

            return errorResponse;
        }

        public async Task<ResultBase<Company>> FindByIdCompany(Guid id)
        {
            var result = await _companyServices.FindByIdCompany(id);

            if (result != null)
            {
                return new ResultBase<Company>
                {
                    Success = true,
                    Message = "Sukses",
                    Model = result
                };
            }

            var errorResponse = new ResultBase<Company>
            {
                Success = false,
                Message = "Data tidak ditemukan",
                Model = result
            };

            return errorResponse;
        }

        public async Task<ResultBase> SaveCompany(CompanyInputRequest request)
        {
            var result = await _companyServices.SaveCompany(request);

            return result;
        }
    }
}
