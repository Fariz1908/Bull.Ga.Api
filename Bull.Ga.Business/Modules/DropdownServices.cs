using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.DtoModels;
using Microsoft.Extensions.Logging;

namespace Bull.Ga.Business.Modules
{
    public class DropdownServices : IDropdownServices
    {
        private readonly IDomainServices _domainServices;
        private readonly ILogger<DropdownServices> _logger;

        public DropdownServices(IDomainServices domainServices, ILogger<DropdownServices> logger)
        {
            _domainServices = domainServices;
            _logger = logger;
        }

        public async Task<List<DropdownResponse>> AssetCatgories(string? filter)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new List<DropdownResponse>();

                    var assetCategories = (from a in _domainServices.GetAllAssetCategories()
                                        where a.Name.ToLower().Contains((filter ?? "").ToLower())
                                        orderby a.Name ascending
                                        select new DropdownResponse
                                        {
                                            Key = a.Id.ToString(),
                                            Value = a.Name ?? string.Empty
                                        }).ToList();

                    if (assetCategories.Count > 0)
                        result = assetCategories;

                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: AssetCatgories(), " +
                    $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }

        public async Task<List<DropdownResponse>> Companies(string? filter)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new List<DropdownResponse>();

                    var companies = (from a in _domainServices.GetAllCompanies()
                                       where a.Code.ToLower().Contains((filter ?? "").ToLower()) ||
                                             a.Name.ToLower().Contains((filter ?? "").ToLower())
                                       orderby a.Code, a.Name ascending
                                       select new DropdownResponse
                                       {
                                           Key = a.Id.ToString(),
                                           Value = string.Concat(a.Code ?? string.Empty, ": ", a.Name ?? string.Empty)
                                       }).ToList();

                    if (companies.Count > 0)
                        result = companies;

                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: Companies(), " +
                    $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }

        public async Task<List<DropdownResponse>> Departments(string? filter)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new List<DropdownResponse>();

                    var departments = (from a in _domainServices.GetAllDepartments()
                                     where a.Code.ToLower().Contains((filter ?? "").ToLower()) ||
                                           a.Name.ToLower().Contains((filter ?? "").ToLower())
                                     orderby a.Code, a.Name ascending
                                     select new DropdownResponse
                                     {
                                         Key = a.Id.ToString(),
                                         Value = string.Concat(a.Code ?? string.Empty, ": ", a.Name ?? string.Empty)
                                     }).ToList();

                    if (departments.Count > 0)
                        result = departments;

                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: Departments(), " +
                    $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }

        public async Task<List<DropdownResponse>> DepreciationMethods(string? filter)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new List<DropdownResponse>();

                    var depreciationMethods = (from a in _domainServices.GetAllDepreciationMethods()
                                               where a.Name.ToLower().Contains((filter ?? "").ToLower())
                                               orderby a.Name ascending
                                               select new DropdownResponse
                                               {
                                                   Key = a.Id.ToString(),
                                                   Value = a.Name ?? string.Empty
                                               }).ToList();

                    if (depreciationMethods.Count > 0)
                        result = depreciationMethods;

                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: DepreciationMethods(), " +
                    $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }

        public async Task<List<DropdownResponse>> Items(string? filter)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new List<DropdownResponse>();

                    var items = (from a in _domainServices.GetAllItems()
                                  where a.Name.ToLower().Contains((filter ?? "").ToLower())
                                  orderby a.Name ascending
                                  select new DropdownResponse
                                               {
                                                   Key = a.Id.ToString(),
                                                   Value = a.Name ?? string.Empty
                                               }).ToList();

                    if (items.Count > 0)
                        result = items;

                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: Items(), " +
                    $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }

        public async Task<List<DropdownResponse>> Locations(string? filter)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var result = new List<DropdownResponse>();

                    var locations = (from a in _domainServices.GetAllLocations()
                                               where a.WorkLocation.ToLower().Contains((filter ?? "").ToLower()) ||
                                                     a.Floor.ToLower().Contains((filter ?? "").ToLower())
                                               orderby a.WorkLocation, a.Floor ascending
                                               select new DropdownResponse
                                               {
                                                   Key = a.Id.ToString(),
                                                   Value = string.Concat(a.WorkLocation ?? string.Empty, " - ", a.Floor ?? string.Empty)
                                               }).ToList();

                    if (locations.Count > 0)
                        result = locations;

                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: DepreciationMethods(), " +
                    $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }
    }
}
