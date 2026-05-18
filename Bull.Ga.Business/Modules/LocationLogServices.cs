using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.Constants;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Data.Models;
using Microsoft.Extensions.Logging;

namespace Bull.Ga.Business.Modules
{
    public class LocationLogServices : ILocationLogServices
    {
        private readonly IDomainServices _domainServices;
        private readonly IProfileServices _profileServices;
        private readonly ILogger<LocationLogServices> _logger;

        public LocationLogServices(IDomainServices domainServices, IProfileServices profileServices, ILogger<LocationLogServices> logger)
        {
            _domainServices = domainServices;
            _profileServices = profileServices;
            _logger = logger;
        }

        public async Task<LocationLogListResponse> FindByFidAssetLocationLog(LocationLogListRequest request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var locationLog = (from a in _domainServices.GetAllLocationLogs()
                                       join b in _domainServices.GetAllAssets() on a.FidAsset equals b.Id
                                       where a.FidAsset == request.FidAsset
                                       select new LocationLogDto
                                       {
                                           Id = a.Id,
                                           TransactionNo = a.TranscationNo,
                                           SubmittedDate = a.SubmittedDate,
                                           ReturnDate = a.ReturnDate,
                                           Location = a.Location,
                                           Remarks = a.Remarks,
                                           CreatedBy = a.CreatedBy,
                                           CreatedAt = a.CreatedAt,
                                           UpdatedBy = a.UpdatedBy,
                                           UpdatedAt = a.UpdatedAt
                                       });

                    var data = PagedList<LocationLogDto>.ToPagedList(locationLog, request.Page, request.Limit);

                    return new LocationLogListResponse
                    {
                        CurrentPage = data.CurrentPage,
                        TotalPages = data.TotalPages,
                        PageSize = data.PageSize,
                        TotalCount = data.TotalCount,
                        FidAsset = request.FidAsset,

                        Items = data
                    };
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: FindByFidAssetLocationLog(), " +
                        $"request: {request}, " +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }

        public async Task<ResultBase> SaveLocationLog(LocationLogInputRequest request)
        {
            return await Task.Run(() =>
            {
                var now = DateTime.Now;
                var userContex = _profileServices.GetUserContext();
                var currentUser = userContex.UserId;
                var currentApp = userContex.AppSource;

                try
                {
                    var result = new ResultBase
                    {
                        Success = false,
                        Message = string.Empty
                    };

                    var locationLog = new LocationLog();
                    if (request.Id == null)
                    {
                        locationLog = new LocationLog
                        {
                            Id = Guid.NewGuid(),
                            TranscationNo = "",
                            FidAsset = request.FidAsset,
                            SubmittedDate = request.SubmittedDate,
                            Location = request.Location,
                            Remarks = request.Remarks,

                            CreatedBy = currentUser,
                            CreatedAt = now,
                        };

                        _domainServices.InsertLocationLog(locationLog);
                    }
                    else
                    {
                        locationLog = _domainServices.GetAllLocationLogs()
                                    .SingleOrDefault(x => x.Id.Equals(request.Id));
                        if (locationLog == null)
                            throw new Exception(MessageConstants.S_DATA_NOT_FOUND);

                        locationLog.SubmittedDate = request.SubmittedDate;
                        locationLog.ReturnDate = request.ReturnDate;
                        locationLog.Location = request.Location;
                        locationLog.Remarks = request.Remarks;

                        locationLog.UpdatedBy = currentUser;
                        locationLog.UpdatedAt = now;

                        _domainServices.UpdateLocationLog(locationLog);
                    }

                    _domainServices.SaveChanges();

                    result.Success = true;
                    result.Message = MessageConstants.S_SAVED_LOC_LOG_SUCCESS;

                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: SaveLocationLog(), " +
                        $"request: {request}, " +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }
    }
}
