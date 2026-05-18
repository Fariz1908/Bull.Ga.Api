using Bull.Ga.Data.Models;

namespace Bull.Ga.Business.Interfaces
{
    public interface IDomainServices
    {
        // Read Models
        IQueryable<AssetCategory> GetAllAssetCategories();
        IQueryable<Asset> GetAllAssets();
        IQueryable<DepreciationMethod> GetAllDepreciationMethods();
        IQueryable<LocationLog> GetAllLocationLogs();

        // Create, Update & Delete
        void InsertAssetCategory(AssetCategory model);
        void UpdateAssetCategory(AssetCategory model);
        void InsertAsset(Asset model);
        void UpdateAsset(Asset model);
        void InsertLocationLog(LocationLog model);
        void UpdateLocationLog(LocationLog model);

        void SaveChanges();
    }
}
