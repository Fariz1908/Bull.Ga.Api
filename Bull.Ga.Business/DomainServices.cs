using Bull.Ga.Business.Interfaces;
using Bull.Ga.Data;
using Bull.Ga.Data.Models;
using Microsoft.Extensions.Logging;

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

        public IQueryable<Company> GetAllCompanies()
        {
            return _dataContext.Companies;
        }

        public IQueryable<Department> GetAllDepartments()
        {
            return _dataContext.Departments;
        }

        public IQueryable<DepreciationMethod> GetAllDepreciationMethods()
        {
            return _dataContext.DepreciationMethods;
        }

        public IQueryable<Item> GetAllItems()
        {
            return _dataContext.Items;
        }

        public IQueryable<Location> GetAllLocations()
        {
            return _dataContext.Locations;
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
                _logger.LogError($"Method: InsertAssetCategory(), " +
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
                _logger.LogError($"Method: UpdateAssetCategory(), " +
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
                _logger.LogError($"Method: InsertAsset(), " +
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
                _logger.LogError($"Method: UpdateAsset(), " +
                    $"model: {model}, " +
                    $"message: {ex.Message}");
                throw;
            }
        }

        public void InsertCompany(Company model)
        {
            try
            {
                _dataContext.Companies.Add(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Method: InsertCompany(), " +
                    $"model: {model}, " +
                    $"message: {ex.Message}");
                throw;
            }
        }

        public void UpdateCompany(Company model)
        {
            try
            {
                _dataContext.Companies.Add(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Method: UpdateCompany(), " +
                    $"model: {model}, " +
                    $"message: {ex.Message}");
                throw;
            }
        }

        public void InsertDepartment(Department model)
        {
            try
            {
                _dataContext.Departments.Add(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Method: InsertDepartment(), " +
                    $"model: {model}, " +
                    $"message: {ex.Message}");
                throw;
            }
        }

        public void UpdateDepartment(Department model)
        {
            try
            {
                _dataContext.Departments.Update(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Method: UpdateDepartment(), " +
                    $"model: {model}, " +
                    $"message: {ex.Message}");
                throw;
            }
        }

        public void InsertItem(Item model)
        {
            try
            {
                _dataContext.Items.Add(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Method: InsertItem(), " +
                    $"model: {model}, " +
                    $"message: {ex.Message}");
                throw;
            }
        }

        public void UpdateItem(Item model)
        {
            try
            {
                _dataContext.Items.Update(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Method: UpdateItem(), " +
                    $"model: {model}, " +
                    $"message: {ex.Message}");
                throw;
            }
        }

        public void InsertLocation(Location model)
        {
            try
            {
                _dataContext.Locations.Add(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Method: InsertLocation(), " +
                    $"model: {model}, " +
                    $"message: {ex.Message}");
                throw;
            }
        }

        public void UpdateLocation(Location model)
        {
            try
            {
                _dataContext.Locations.Update(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Method: UpdateLocation(), " +
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
                _logger.LogError($"Method: InsertLocationLog(), " +
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
                _logger.LogError($"Method: UpdateLocationLog(), " +
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
