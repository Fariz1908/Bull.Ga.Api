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

        public IQueryable<Asset> GetAllAssets()
        {
            return _dataContext.Assets;
        }

        public IQueryable<DepreciationMethod> GetAllDepreciationMethods()
        {
            return _dataContext.DepreciationMethods;
        }

        public IQueryable<LocationLog> GetAllLocationLogs()
        {
            return _dataContext.LocationLogs;
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

        public void InsertAsset(Asset model)
        {
            try
            {
                _dataContext.Assets.Add(model);
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"Method: InsertAsset(), " +
                    $"model: {model}, " +
                    $"message: {ex.Message}");
                throw;
            }
        }

        public void UpdateAsset(Asset model)
        {
            try
            {
                _dataContext.Assets.Add(model);
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"Method: UpdateAsset(), " +
                    $"model: {model}, " +
                    $"message: {ex.Message}");
                throw;
            }
        }

        public void InsertLocationLog(LocationLog model)
        {
            try
            {
                _dataContext.LocationLogs.Add(model);
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"Method: InsertLocationLog(), " +
                    $"model: {model}, " +
                    $"message: {ex.Message}");
                throw;
            }
        }

        public void UpdateLocationLog(LocationLog model)
        {
            try
            {
                _dataContext.LocationLogs.Add(model);
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"Method: UpdateLocationLog(), " +
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
