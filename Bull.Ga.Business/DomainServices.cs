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

        public IQueryable<DepreciationMethod> GetAllDepreciationMethods()
        {
            return _dataContext.DepreciationMethods;
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }
    }
}
