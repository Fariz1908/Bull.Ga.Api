using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.Constants;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Data.Models;
using Microsoft.Extensions.Logging;

namespace Bull.Ga.Business.Modules
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDomainServices _domainServices;
        private readonly IProfileServices _profileServices;
        private readonly ILogger<DepartmentServices> _logger;

        public DepartmentServices(IDomainServices domainServices, IProfileServices profileServices, ILogger<DepartmentServices> logger)
        {
            _domainServices = domainServices;
            _profileServices = profileServices;
            _logger = logger;
        }

        public async Task<DepartmentListResponse> FindAllDepartment(DepartmentListRequest request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var departments = (from a in _domainServices.GetAllDepartments()
                                       where a.Name.ToLower().Contains(request.DeptName.ToLower())
                                       orderby a.Name ascending
                                       select new Department
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

                    var data = PagedList<Department>.ToPagedList(departments, request.Page, request.Limit);

                    return new DepartmentListResponse
                    {
                        CurrentPage = data.CurrentPage,
                        TotalPages = data.TotalPages,
                        PageSize = data.PageSize,
                        TotalCount = data.TotalCount,
                        Code = request.Code ?? string.Empty,
                        DeptName = request.DeptName,

                        Items = data
                    };
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: FindAllDepartment(), " +
                        $"request: {request}, " +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }

        public async Task<Department> FindByIdDepartment(Guid id)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var department = (from a in _domainServices.GetAllDepartments()
                                    where a.Id == id
                                    select new Department
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
                    if (department == null)
                        throw new Exception(MessageConstants.S_DATA_NOT_FOUND);

                    return department;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: FindByIdDepartment(), " +
                        $"request: {id}, " +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }

        public async Task<ResultBase> SaveDepartment(DepartmentInputRequest request)
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

                    var department = new Department();
                    if (request.Id != null)
                    {
                        var existDepartment = _domainServices.GetAllDepartments()
                                                .SingleOrDefault(x => x.Code.Trim().ToLower().Equals(request.Code.Trim().ToLower())
                                                && x.Name.Trim().ToLower().Equals(request.DeptName.ToLower())
                                                && x.Id != request.Id);
                        if (existDepartment != null)
                            throw new Exception(MessageConstants.S_EXISTS_DEPARTMENT);

                        department = _domainServices.GetAllDepartments().SingleOrDefault(x => x.Id.Equals(request.Id));
                        if (department == null)
                            throw new Exception(MessageConstants.S_DATA_NOT_FOUND);

                        department.Name = request.DeptName.Trim().ToUpper();
                        department.IsActive = request.IsActive;

                        department.UpdatedBy = currentUser;
                        department.UpdatedAt = now;

                        _domainServices.UpdateDepartment(department);
                    }
                    else
                    {
                        var existDepartment = _domainServices.GetAllDepartments()
                                                .SingleOrDefault(x => x.Code.Trim().ToLower().Equals(request.Code.Trim().ToLower())
                                                && x.Name.Trim().ToLower().Equals(request.DeptName.ToLower()));
                        if (existDepartment != null)
                            throw new Exception(MessageConstants.S_EXISTS_DEPARTMENT);

                        department = new Department
                        {
                            Id = Guid.NewGuid(),
                            Code = request.Code.ToUpper(),
                            Name = request.DeptName.ToUpper(),
                            IsActive = request.IsActive,

                            CreatedBy = currentUser,
                            CreatedAt = now,
                        };

                        _domainServices.InsertDepartment(department);
                    }

                    _domainServices.SaveChanges();

                    result.Success = true;
                    result.Message = MessageConstants.S_SAVED_DEPARTMENT_SUCCESS;

                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: SaveDepartment(), " +
                        $"request: {request}, " +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }
    }
}
