using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.Constants;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Data.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bull.Ga.Business.Modules
{
    public class AssetServices : IAssetServices
    {
        private readonly IDomainServices _domainServices;
        private readonly ILogger<AssetServices> _logger;
        private readonly IProfileServices _profileServices;

        public AssetServices(IDomainServices domainServices, ILogger<AssetServices> logger, IProfileServices profileServices)
        {
            _domainServices = domainServices;
            _logger = logger;
            _profileServices = profileServices;
        }

        public async Task<ResultBase> SaveAsset(AssetInputRequest request)
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
                                FidDepreciationMethod = request.IdDepreciationMethod,
                                ResidualValue = request.ResidualValue,
                                IsActive = true,

                                CreatedBy = currentUser,
                                CreatedAt = now,
                            };

                            _domainServices.InsertAssetCategory(assetCategory);
                        }

                        _domainServices.SaveChanges();

                        result.Success = true;
                        result.Message = MessageConstants.S_SAVED_ASSET_SUCCESS;

                        return result;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"method: SaveAsset(), " +
                            $"request: {request}" +
                            $"message: {ex.Message}");
                        throw;
                    }
                }).ConfigureAwait(false);
        }
    }
}
