using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Data.Models;
using Microsoft.Extensions.Logging;

namespace Bull.Ga.Business.Modules
{
    public class BpathServices : IBpathDataServices
    {
        private readonly IDomainServices _domainServices;
        private readonly ILogger<BpathServices> _logger;

        public BpathServices(IDomainServices domainServices, ILogger<BpathServices> logger)
        {
            _domainServices = domainServices;
            _logger = logger;
        }

        public async Task<EmployeeListResponse> FindAllEmployees(EmployeeListRequest request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var employees = (from a in _domainServices.GetAllEmployees()
                                     where a.Nik.ToLower().Contains(request.Nik.ToLower()) ||
                                     a.Name.ToLower().Contains(request.Name.ToLower())
                                     orderby a.Name ascending
                                     select new Employee
                                     {
                                         Id = a.Id,
                                         Nik = a.Nik,
                                         Name = a.Name,
                                         NickName = a.NickName,
                                         IsDeleted = a.IsDeleted
                                     });

                    employees = employees.Where(x => x.IsDeleted == false);

                    var data = PagedList<Employee>.ToPagedList(employees, request.Page, request.Limit);

                    return new EmployeeListResponse
                    {
                        CurrentPage = data.CurrentPage,
                        TotalPages = data.TotalPages,
                        PageSize = data.PageSize,
                        TotalCount = data.TotalCount,
                        Nik = request.Nik,
                        Name = request.Name,
 
                        Items = data
                    };
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: FindAllEmployees(), " +
                        $"request: {request}, " +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }

        public async Task<PoDetailListResponse> FindAllPoDetails(PoDetailListRequest request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var poDetails = (from a in _domainServices.GetAllPoBpath()
                                     join b in _domainServices.GetAllPoDetailBpath() on a.PoIdNo equals b.FidPo
                                     join c in _domainServices.GetAllPrBpath() on a.FidPr equals c.Id
                                     where a.PoNo.ToLower().Contains(request.PoNo.ToLower()) &&
                                        c.PrNo.ToLower().Contains(request.PrNo.ToLower()) &&
                                        a.Title.ToLower().Contains(request.Title.ToLower()) &&
                                        b.Item.ToLower().Contains(request.Title.ToLower())
                                     orderby a.PoNo descending
                                     select new PoDetailDto
                                     {
                                         Id = a.Id,
                                         PrNo = c.PrNo ?? string.Empty,
                                         PoNo = a.PoNo ?? string.Empty,
                                         PoIdNo = a.PoIdNo ?? string.Empty,
                                         PoTitle = a.Title ?? string.Empty,
                                         Currency = a.Currency ?? string.Empty,
                                         Item = b.Item ?? string.Empty,
                                         Qty = b.Quantity == null ? 0 : int.Parse(b.Quantity),
                                         Unit = b.Unit ?? string.Empty,
                                         UnitPrice = b.UnitPrice == null ? 0 : int.Parse(b.UnitPrice),
                                         Discount = b.Discount == null ? 0 : int.Parse(b.Discount),
                                         CreatedBy = a.CreatedBy ?? string.Empty,
                                         CreatedDate = a.CreatedDate
                                     });

                    var data = PagedList<PoDetailDto>.ToPagedList(poDetails, request.Page, request.Limit);

                    return new PoDetailListResponse
                    {
                        CurrentPage = data.CurrentPage,
                        TotalPages = data.TotalPages,
                        PageSize = data.PageSize,
                        TotalCount = data.TotalCount,
                        PoNo = request.PoNo ?? string.Empty,
                        PrNo = request.PrNo ?? string.Empty,
                        Title = request.Title ?? string.Empty,
                        Item = request.Item ?? string.Empty,

                        Items = data
                    };
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: FindAllPoDetails(), " +
                        $"request: {request}, " +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }
    }
}
