using Bull.Ga.Data.Models;

namespace Bull.Ga.Business.Interfaces
{
    public interface IDomainServices
    {
        // Read Models
        IQueryable<AssetCategory> GetAllAssetCategories();
        IQueryable<DepreciationMethod> GetAllDepreciationMethods();

        // Create, Update & Delete
        void InsertAssetCategory(AssetCategory model);
        void UpdateAssetCategory(AssetCategory model);

        void SaveChanges();
    }
}
