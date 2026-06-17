using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.Constants;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Data.Models;
using Microsoft.Extensions.Logging;

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

                    var asset = new Asset();
                    if (request.Id != null)
                    {
                        asset = _domainServices.GetAllAssets().SingleOrDefault(x => x.Id.Equals(request.Id));
                        if (asset == null)
                            throw new Exception(MessageConstants.S_DATA_NOT_FOUND);

                        asset.FidItem = request.FidItem;
                        asset.Merk = request.Merk.ToUpper();
                        asset.SerialNumber = request.SerialNumber;
                        asset.FidCompany = request.FidCompany;
                        asset.FidDepartment = request.FidDepartment;
                        //asset.FidDeliveryOrder = request.FidDeliveryOrder;
                        asset.RefPoNo = request.RefPoNo;
                        asset.PurchaseDate = request.PurchaseDate;
                        asset.Supplier = request.Supplier;
                        asset.PurchaseAmount = request.PurchaseAmount;
                        asset.Remark = request.Remark;

                        asset.UpdatedBy = currentUser;
                        asset.UpdatedAt = now;

                        _domainServices.UpdateAsset(asset);
                    }
                    else
                    {
                        string assetNo = GenerateAssetNo(request.FidCompany, request.FidDepartment, request.FidItem, request.PurchaseDate);
                        if (string.IsNullOrEmpty(assetNo))
                            throw new Exception("Generate Asset No Error");

                        asset = new Asset
                        {
                            Id = Guid.NewGuid(),
                            AssetNo = assetNo,
                            FidItem = request.FidItem,
                            Merk = request.Merk,
                            SerialNumber = request.SerialNumber,
                            FidCompany = request.FidCompany,
                            FidDepartment = request.FidDepartment,
                            //FidDeliveryOrder = request.FidDeliveryOrder,
                            RefPoNo = request.RefPoNo,
                            PurchaseDate = request.PurchaseDate,
                            PurchaseAmount = request.PurchaseAmount,
                            Remark = request.Remark,

                            CreatedBy = currentUser,
                            CreatedAt = now,
                        };

                        _domainServices.InsertAsset(asset);
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

        private string GenerateAssetNo(Guid companyId, Guid departmentId, Guid itemId, DateOnly purchaseDate)
        {
            string companyCode = _domainServices.GetAllCompanies()
                                .Where(x => x.Id == companyId)
                                .Select(x => x.Code)
                                .SingleOrDefault() ?? string.Empty;

            string deptCode = _domainServices.GetAllDepartments()
                                .Where(x => x.Id == departmentId)
                                .Select(x => x.Code)
                                .SingleOrDefault() ?? string.Empty;

            string itemCode = _domainServices.GetAllItems()
                        .Where(x => x.Id == itemId)
                        .Select(x => x.Code)
                        .SingleOrDefault() ?? string.Empty;

            string strPurchaseDate = purchaseDate.ToString("MM-yyyy");

            int maxId = _domainServices.GetAllAssets()
                        .Where(x => x.AssetNo.Contains(companyCode))
                        .Select(x => int.Parse(x.AssetNo.Split('/').Last()))
                        .DefaultIfEmpty(0)
                        .Max();
            int nextId = maxId++;

            string generateAssetNo = string.Concat(companyCode,"/",deptCode,"/",itemCode,"/",strPurchaseDate,"/",nextId.ToString("D3"));

            return generateAssetNo;
        }
    }
}
