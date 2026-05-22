using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Data.Models;

namespace Bull.Ga.Business.Interfaces
{
    public interface ICompanyFacades
    {
        Task<ResultBase<CompanyListResponse>> FindAllCompany(CompanyListRequest request);
        Task<ResultBase<Company>> FindByIdCompany(Guid id);
        Task<ResultBase> SaveCompany(CompanyInputRequest request);
    }
}
