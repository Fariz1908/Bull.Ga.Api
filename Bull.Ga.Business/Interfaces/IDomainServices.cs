using Bull.Ga.Data.Models;

namespace Bull.Ga.Business.Interfaces
{
    public interface IDomainServices
    {
        // Read Models
        IQueryable<AssetCategory> GetAllAssetCategories();
        IQueryable<Asset> GetAllAssets();
        IQueryable<Company> GetAllCompanies();
        IQueryable<Department> GetAllDepartments();
        IQueryable<DepreciationMethod> GetAllDepreciationMethods();
        IQueryable<Item> GetAllItems();
        IQueryable<Location> GetAllLocations();
        IQueryable<LocationLog> GetAllLocationLogs();

        // Create, Update & Delete
        void InsertAssetCategory(AssetCategory model);
        void UpdateAssetCategory(AssetCategory model);
        void InsertAsset(Asset model);
        void UpdateAsset(Asset model);
        void InsertCompany(Company model);
        void UpdateCompany(Company model);
        void InsertDepartment(Department model);
        void UpdateDepartment(Department model);
        void InsertItem(Item model);
        void UpdateItem(Item model);
        void InsertLocation(Location model);
        void UpdateLocation(Location model);
        void InsertLocationLog(LocationLog model);
        void UpdateLocationLog(LocationLog model);

        void SaveChanges();
    }
}
