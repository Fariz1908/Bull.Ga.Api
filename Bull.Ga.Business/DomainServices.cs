using Bull.Ga.Business.Interfaces;
using Bull.Ga.Data;
using Bull.Ga.Data.Models;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Bull.Ga.Business
{
    public class DomainServices : IDomainServices
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<DomainServices> _logger;

        public DomainServices(DataContext dataContext, ILogger<DomainServices> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public IQueryable<AssetCategory> GetAllAssetCategories()
        {
            return _dataContext.AssetCategories;
        }

        public IQueryable<DepreciationMethod> GetAllDepreciationMethods()
        {
            return _dataContext.DepreciationMethods;
        }

        public void InsertAssetCategory(AssetCategory model)
        {
            try
            {
                _dataContext.AssetCategories.Add(model);
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"Method: InsertAssetCategory(), " +
                    $"model: {model}, " +
                    $"message: {ex.Message}");
                throw;
            }
        }

        public void UpdateAssetCategory(AssetCategory model)
        {
            try
            {
                _dataContext.AssetCategories.Update(model);
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"Method: UpdateAssetCategory(), " +
                    $"model: {model}, " +
                    $"message: {ex.Message}");
                throw;
            }
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }
    }
}
