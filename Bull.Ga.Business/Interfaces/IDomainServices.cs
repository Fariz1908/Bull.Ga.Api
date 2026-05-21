using Bull.Ga.Data.Models;

namespace Bull.Ga.Business.Interfaces
{
    public interface IDomainServices
    {
        // Read Models
        IQueryable<AssetCategory> GetAllAssetCategories();
        IQueryable<Asset> GetAllAssets();
        IQueryable<Department> GetAllDepartments();
        IQueryable<DepreciationMethod> GetAllDepreciationMethods();
        IQueryable<Location> GetAllLocations();
        IQueryable<LocationLog> GetAllLocationLogs();

        // Create, Update & Delete
        void InsertAssetCategory(AssetCategory model);
        void UpdateAssetCategory(AssetCategory model);
        void InsertAsset(Asset model);
        void UpdateAsset(Asset model);
        void InsertDepartment(Department model);
        void UpdateDepartment(Department model);
        void InsertLocation(Location model);
        void UpdateLocation(Location model);
        void InsertLocationLog(LocationLog model);
        void UpdateLocationLog(LocationLog model);

        void SaveChanges();
    }
}
