using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.Constants;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Data.Models;
using Microsoft.Extensions.Logging;

namespace Bull.Ga.Business.Modules
{
    public class ItemServices : IItemServices
    {
        private readonly IDomainServices _domainServices;
        private readonly IProfileServices _profileServices;
        private readonly ILogger<ItemServices> _logger;

        public ItemServices(IDomainServices domainServices, IProfileServices profileServices, ILogger<ItemServices> logger)
        {
            _domainServices = domainServices;
            _profileServices = profileServices;
            _logger = logger;
        }

        public async Task<ItemListResponse> FindAllItems(ItemListRequest request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var items = (from a in _domainServices.GetAllItems()
                                 join b in _domainServices.GetAllAssetCategories() on a.FidAssetCategory equals b.Id
                                 where a.Name.ToLower().Contains(request.ItemName.ToLower()) &&
                                    b.Name.ToLower().Contains(request.AssetCategoryName.ToLower())
                                 select new ItemDto
                                 {
                                     Id = a.Id,
                                     ItemName = a.Name,
                                     FidAssetCategory = a.FidAssetCategory,
                                     AssetCategoryName = b.Name,
                                     IsActive = a.IsActive ?? false,
                                     CreatedBy = a.CreatedBy,
                                     CreatedAt = a.CreatedAt,
                                     UpdatedBy = a.UpdatedBy,
                                     UpdatedAt = a.UpdatedAt
                                 });

                    var data = PagedList<ItemDto>.ToPagedList(items, request.Page, request.Limit);

                    return new ItemListResponse
                    {
                        CurrentPage = data.CurrentPage,
                        TotalPages = data.TotalPages,
                        PageSize = data.PageSize,
                        TotalCount = data.TotalCount,
                        ItemName = request.ItemName ?? string.Empty,
                        AssetCategoryName = request.AssetCategoryName ?? string.Empty,

                        Items = data
                    };
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: FindAllLocation(), " +
                        $"request: {request}, " +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }

        public async Task<ItemDto> FindItemById(Guid id)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var item = (from a in _domainServices.GetAllItems()
                                join b in _domainServices.GetAllAssetCategories() on a.FidAssetCategory equals b.Id
                                where a.Id == id
                                select new ItemDto
                                {
                                    Id = a.Id,
                                    ItemName = a.Name,
                                    FidAssetCategory = a.FidAssetCategory,
                                    AssetCategoryName = b.Name,
                                    IsActive = a.IsActive ?? false,
                                    CreatedBy = a.CreatedBy,
                                    CreatedAt = a.CreatedAt,
                                    UpdatedBy = a.UpdatedBy,
                                    UpdatedAt = a.UpdatedAt
                                }).SingleOrDefault();
                    if (item == null)
                        throw new Exception(MessageConstants.S_DATA_NOT_FOUND);

                    return item;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: FindItemById(), " +
                        $"id: {id}, " +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }

        public async Task<ResultBase> SaveItem(ItemInputRequest request)
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

                    var item = new Item();
                    if (request.Id == null)
                    {
                        var existItem = _domainServices.GetAllItems()
                                        .SingleOrDefault(x => x.Name.Trim().ToLower() == request.ItemName.Trim().ToLower() 
                                        && x.FidAssetCategory == request.FidAssetCategory
                                        && x.Id == request.Id);
                        if (existItem != null)
                            throw new Exception(MessageConstants.S_EXISTS_ITEM);

                        item = _domainServices.GetAllItems().SingleOrDefault(x => x.Id == request.Id);
                        if (item == null)
                            throw new Exception(MessageConstants.S_DATA_NOT_FOUND);

                        item.Name = request.ItemName.Trim().ToUpper();
                        item.FidAssetCategory = request.FidAssetCategory;
                        item.IsActive = request.IsActive;

                        item.UpdatedBy = currentUser;
                        item.UpdatedAt = now;

                        _domainServices.UpdateItem(item);
                    }
                    else
                    {
                        var existItem = _domainServices.GetAllItems()
                                        .SingleOrDefault(x => x.Name.Trim().ToLower() == request.ItemName.Trim().ToLower()
                                        && x.FidAssetCategory == request.FidAssetCategory);
                        if (existItem != null)
                            throw new Exception(MessageConstants.S_EXISTS_ITEM);

                        item = new Item
                        {
                            Id = Guid.NewGuid(),
                            Name = request.ItemName.Trim().ToUpper(),
                            FidAssetCategory = request.FidAssetCategory,
                            IsActive = request.IsActive,

                            CreatedBy = currentUser,
                            CreatedAt = now,
                        };

                        _domainServices.InsertItem(item);
                    }

                    _domainServices.SaveChanges();

                    result.Success = true;
                    result.Message = MessageConstants.S_SAVED_ITEM_SUCCESS;

                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: SaveItem(), " +
                        $"request: {request}, " +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }
    }
}
