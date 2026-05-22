using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.Constants;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Data.Models;
using Microsoft.Extensions.Logging;

namespace Bull.Ga.Business.Modules
{
    public class CompanyServices : ICompanyServices
    {
        private readonly IDomainServices _domainServices;
        private readonly IProfileServices _profileServices;
        private readonly ILogger<CompanyServices> _logger;

        public CompanyServices(IDomainServices domainServices, IProfileServices profileServices, ILogger<CompanyServices> logger)
        {
            _domainServices = domainServices;
            _profileServices = profileServices;
            _logger = logger;
        }

        public async Task<CompanyListResponse> FindAllCompany(CompanyListRequest request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var companies = (from a in _domainServices.GetAllCompanies()
                                     where a.Code.ToLower().Contains(request.Code.ToLower()) &&
                                        a.Name.ToLower().Contains(request.CompanyName.ToLower())
                                     orderby a.Name, a.Code ascending
                                     select new Company
                                     {
                                         Id = a.Id,
                                         Code = a.Code,
                                         Name = a.Name,
                                         IsActive = a.IsActive,
                                         CreatedBy = a.CreatedBy,
                                         CreatedAt = a.CreatedAt,
                                         UpdatedBy = a.UpdatedBy,
                                         UpdatedAt = a.UpdatedAt
                                     });

                    var data = PagedList<Company>.ToPagedList(companies, request.Page, request.Limit);

                    return new CompanyListResponse
                    {
                        CurrentPage = data.CurrentPage,
                        TotalPages = data.TotalPages,
                        PageSize = data.PageSize,
                        TotalCount = data.TotalCount,
                        Code = request.Code ?? string.Empty,
                        CompanyName = request.CompanyName ?? string.Empty,

                        Items = data
                    };
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: FindAllCompany(), " +
                        $"request: {request}, " +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }

        public async Task<Company> FindByIdCompany(Guid id)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var company = (from a in _domainServices.GetAllCompanies()
                                   where a.Id == id
                                   select new Company
                                   {
                                       Id = a.Id,
                                       Code = a.Code,
                                       Name = a.Name,
                                       IsActive = a.IsActive,
                                       CreatedBy = a.CreatedBy,
                                       CreatedAt = a.CreatedAt,
                                       UpdatedBy = a.UpdatedBy,
                                       UpdatedAt = a.UpdatedAt
                                   }).SingleOrDefault();
                    if (company == null)
                        throw new Exception(MessageConstants.S_DATA_NOT_FOUND);

                    return company;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: FindByIdCompany(), " +
                        $"request: {id}, " +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }

        public async Task<ResultBase> SaveCompany(CompanyInputRequest request)
        {
            return await Task.Run(() =>
            {
                var now = DateTime.Now;
                var userContext = _profileServices.GetUserContext();
                var currentUser = userContext.UserId;
                var currentApp = userContext.AppSource;

                try
                {
                    var result = new ResultBase
                    {
                        Success = false,
                        Message = string.Empty
                    };

                    var company = new Company();
                    if (request.Id != null)
                    {
                        var existCompany = _domainServices.GetAllCompanies()
                                                .SingleOrDefault(x => x.Name.Trim().ToLower().Equals(request.CompanyName.Trim().ToLower())
                                                && x.Code.Trim().ToLower().Equals(request.Code.ToLower())
                                                && x.Id != request.Id);
                        if (existCompany != null)
                            throw new Exception(MessageConstants.S_EXISTS_COMPANY);

                        company = _domainServices.GetAllCompanies().SingleOrDefault(x => x.Id.Equals(request.Id));
                        if (company == null)
                            throw new Exception(MessageConstants.S_DATA_NOT_FOUND);

                        company.Name = request.CompanyName.Trim().ToUpper();
                        company.IsActive = request.IsActive;

                        company.UpdatedBy = currentUser;
                        company.UpdatedAt = now;

                        _domainServices.UpdateCompany(company);
                    }
                    else
                    {
                        var existCompany = _domainServices.GetAllCompanies()
                                                .SingleOrDefault(x => x.Name.Trim().ToLower().Equals(request.CompanyName.Trim().ToLower())
                                                && x.Code.Trim().ToLower().Equals(request.Code.ToLower()));
                        if (existCompany != null)
                            throw new Exception(MessageConstants.S_EXISTS_COMPANY);

                        company = new Company
                        {
                            Id = Guid.NewGuid(),
                            Code = request.Code.ToUpper(),
                            Name = request.CompanyName.ToUpper(),
                            IsActive = request.IsActive,

                            CreatedBy = currentUser,
                            CreatedAt = now,
                        };

                        _domainServices.InsertCompany(company);
                    }

                    _domainServices.SaveChanges();

                    result.Success = true;
                    result.Message = MessageConstants.S_SAVED_COMPANY_SUCCESS;

                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: SaveCompany(), " +
                        $"request: {request}, " +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }
    }
}
