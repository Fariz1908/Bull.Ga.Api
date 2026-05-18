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
    }
}
