using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.Constants;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Data.Models;
using Microsoft.Extensions.Logging;

namespace Bull.Ga.Business.Modules
{
    public class AssetCategoryServices : IAssetCategoryServices
    {
        private readonly IDomainServices _domainServices;
        private readonly ILogger<AssetCategoryServices> _logger;
        private readonly IProfileServices _profileServices;

        public AssetCategoryServices(IDomainServices domainServices, ILogger<AssetCategoryServices> logger, IProfileServices profileServices)
        {
            _domainServices = domainServices;
            _logger = logger;
            _profileServices = profileServices;
        }

        public async Task<AssetCategoryListResponse> FindAllAssetCategory(AssetCategoryListRequest request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var assetCategory = (from a in _domainServices.GetAllAssetCategories()
                                         join b in _domainServices.GetAllDepreciationMethods() on a.FidDepreciationMethod equals b.Id
                                         where a.Name.ToLower().Contains(request.CategoryName.ToLower())
                                         select new AssetCategoryDto
                                         {
                                             Id = a.Id,
                                             Name = a.Name ?? string.Empty,
                                             UsefulLifeYear = a.UsefulLifeYear,
                                             IdDepreciationMethod = a.FidDepreciationMethod,
                                             DepreciationMethod = b.Description ?? string.Empty,
                                             ResidualValue = a.ResidualValue,
                                             IsActive = a.IsActive ?? false,
                                             CreatedBy = a.CreatedBy,
                                             CreatedAt = a.CreatedAt,
                                             UpdatedBy = a.UpdatedBy,
                                             UpdatedAt = a.UpdatedAt
                                         });

                    var data = PagedList<AssetCategoryDto>.ToPagedList(assetCategory, request.Page, request.Limit);

                    return new AssetCategoryListResponse
                    {
                        CurrentPage = data.CurrentPage,
                        TotalPages = data.TotalPages,
                        PageSize = data.PageSize,
                        TotalCount = data.TotalCount,
                        CategoryName = request.CategoryName ?? string.Empty,

                        Items = data
                    };
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: FindAllAssetCategory(), " +
                        $"request: {request}, " +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }

        public async Task<AssetCategoryDto> FindByIdAssetCategory(int id)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var assetCategory = (from a in _domainServices.GetAllAssetCategories()
                                         join b in _domainServices.GetAllDepreciationMethods() on a.FidDepreciationMethod equals b.Id
                                         where a.Id == id
                                         select new AssetCategoryDto
                                         {
                                             Id = a.Id,
                                             Name = a.Name ?? string.Empty,
                                             UsefulLifeYear = a.UsefulLifeYear,
                                             IdDepreciationMethod = a.FidDepreciationMethod,
                                             DepreciationMethod = b.Description ?? string.Empty,
                                             ResidualValue = a.ResidualValue,
                                             IsActive = a.IsActive ?? false,
                                             CreatedBy = a.CreatedBy,
                                             CreatedAt = a.CreatedAt,
                                             UpdatedBy = a.UpdatedBy,
                                             UpdatedAt = a.UpdatedAt
                                         }).SingleOrDefault();
                    if (assetCategory == null)
                        throw new Exception(MessageConstants.S_DATA_NOT_FOUND);

                    return assetCategory;

                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: FindByIdAssetCategory(), " +
                        $"Id: {id}" +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }

        public async Task<ResultBase> SaveAssetCategory(AssetCategoryInputRequest request)
        {
            return await Task.Run(() =>
            {
                var now = DateTime.Now;
                var userContext = _profileServices.GetUserContext();
                var currentUser = userContext.UserId;
                var currentApp = userContext.AppSource;

                try
                {
                    var result = new ResultBase
                    {
                        Success = false,
                        Message = string.Empty
                    };

                    int maxId = _domainServices.GetAllAssetCategories().DefaultIfEmpty().Max(x => x == null ? 0 : x.Id);

                    var assetCategory = new AssetCategory();
                    if (request.Id != null)
                    {
                        var existAssetCategory = _domainServices.GetAllAssetCategories()
                                                .SingleOrDefault(x => x.Name.Trim().ToLower().Equals(request.Name.Trim().ToLower())
                                                && x.Id != request.Id);
                        if (existAssetCategory != null)
                            throw new Exception(MessageConstants.S_EXISTS_ASSET_CATEGORY);

                        assetCategory = _domainServices.GetAllAssetCategories().SingleOrDefault(x => x.Id.Equals(request.Id));
                        if (assetCategory == null)
                            throw new Exception(MessageConstants.S_DATA_NOT_FOUND);

                        assetCategory.Name = request.Name.Trim().ToUpper();
                        assetCategory.UsefulLifeYear = request.UsefulLifeYear;
                        assetCategory.FidDepreciationMethod = request.IdDepreciationMethod;
                        assetCategory.ResidualValue = request.ResidualValue;
                        assetCategory.IsActive = request.IsActive;

                        assetCategory.UpdatedBy = currentUser;
                        assetCategory.UpdatedAt = now;

                        _domainServices.UpdateAssetCategory(assetCategory);
                    }
                    else
                    {
                        var existAssetCategory = _domainServices.GetAllAssetCategories()
                                                .SingleOrDefault(x => x.Name.Trim().ToLower().Equals(request.Name.Trim().ToLower()));
                        if (existAssetCategory != null)
                            throw new Exception(MessageConstants.S_EXISTS_ASSET_CATEGORY);

                        assetCategory = new AssetCategory
                        {
                            Id = ++maxId,
                            Name = request.Name,
                            UsefulLifeYear = request.UsefulLifeYear,
                            FidDepreciationMethod=request.IdDepreciationMethod,
                            ResidualValue = request.ResidualValue,
                            IsActive = true,

                            CreatedBy = currentUser,
                            CreatedAt = now,
                        };

                        _domainServices.InsertAssetCategory(assetCategory);
                    }

                    _domainServices.SaveChanges();

                    result.Success = true;
                    result.Message = MessageConstants.S_SAVED_ASSET_CATEGORY_SUCCESS;

                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: SaveAssetCategory(), " +
                        $"request: {request}" +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }
    }
}
