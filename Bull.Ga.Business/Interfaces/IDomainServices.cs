using Bull.Ga.Data.Models;

namespace Bull.Ga.Business.Interfaces
{
    public interface IDomainServices
    {
        // Read Models
        IQueryable<DepreciationMethod> GetAllDepreciationMethods();

        void SaveChanges();
    }
}
