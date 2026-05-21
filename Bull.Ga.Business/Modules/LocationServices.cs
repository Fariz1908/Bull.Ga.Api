using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.Constants;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Data.Models;
using Microsoft.Extensions.Logging;

namespace Bull.Ga.Business.Modules
{
    public class LocationServices : ILocationServices
    {
        private readonly IDomainServices _domainServices;
        private readonly IProfileServices _profileServices;
        private readonly ILogger<LocationServices> _logger;

        public LocationServices(IDomainServices domainServices, IProfileServices profileServices, ILogger<LocationServices> logger)
        {
            _domainServices = domainServices;
            _profileServices = profileServices;
            _logger = logger;
        }

        public async Task<LocationListResponse> FindAllLocation(LocationListRequest request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var locations = (from a in _domainServices.GetAllLocations()
                                 where a.WorkLocation.ToLower().Contains(request.WorkLocation.ToLower()) &&
                                    a.Floor.ToLower().Contains(request.Floor.ToLower())
                                 orderby a.WorkLocation, a.Floor ascending
                                 select new Location
                                 {
                                     Id = a.Id,
                                     WorkLocation = a.WorkLocation,
                                     Floor = a.Floor,
                                     IsActive = a.IsActive,
                                     CreatedBy = a.CreatedBy,
                                     CreatedAt = a.CreatedAt,
                                     UpdatedBy = a.UpdatedBy,
                                     UpdatedAt = a.UpdatedAt
                                 });

                    var data = PagedList<Location>.ToPagedList(locations, request.Page, request.Limit);

                    return new LocationListResponse
                    {
                        CurrentPage = data.CurrentPage,
                        TotalPages = data.TotalPages,
                        PageSize = data.PageSize,
                        TotalCount = data.TotalCount,
                        WorkLocation = request.WorkLocation ?? string.Empty,
                        Floor = request.Floor ?? string.Empty,

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

        public async Task<Location> FindByIdLocation(Guid id)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var location = (from a in _domainServices.GetAllLocations()
                                    where a.Id == id
                                    select new Location
                                    {
                                        Id = a.Id,
                                        WorkLocation = a.WorkLocation,
                                        Floor = a.Floor,
                                        IsActive = a.IsActive,
                                        CreatedBy = a.CreatedBy,
                                        CreatedAt = a.CreatedAt,
                                        UpdatedBy = a.UpdatedBy,
                                        UpdatedAt = a.UpdatedAt
                                    }).SingleOrDefault();
                    if (location == null)
                        throw new Exception(MessageConstants.S_DATA_NOT_FOUND);

                    return location;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: FindByIdLocation(), " +
                        $"request: {id}, " +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }

        public async Task<ResultBase> SaveLocation(LocationInputRequest request)
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

                    var location = new Location();
                    if (request.Id != null)
                    {
                        var existLocation = _domainServices.GetAllLocations()
                                                .SingleOrDefault(x => x.WorkLocation.Trim().ToLower().Equals(request.WorkLocation.Trim().ToLower())
                                                && x.Floor.Trim().ToLower().Equals(request.Floor.ToLower())
                                                && x.Id != request.Id);
                        if (existLocation != null)
                            throw new Exception(MessageConstants.S_EXISTS_LOCATION_FLOOR);

                        location = _domainServices.GetAllLocations().SingleOrDefault(x => x.Id.Equals(request.Id));
                        if (location == null)
                            throw new Exception(MessageConstants.S_DATA_NOT_FOUND);

                        location.WorkLocation = request.WorkLocation.Trim().ToUpper();
                        location.Floor = request.Floor.Trim().ToUpper();
                        location.IsActive = request.IsActive;
                        
                        location.UpdatedBy = currentUser;
                        location.UpdatedAt = now;

                        _domainServices.UpdateLocation(location);
                    }
                    else
                    {
                        var existLocation = _domainServices.GetAllLocations()
                                                .SingleOrDefault(x => x.WorkLocation.Trim().ToLower().Equals(request.WorkLocation.Trim().ToLower())
                                                && x.Floor.Trim().ToLower().Equals(request.Floor.ToLower()));
                        if (existLocation != null)
                            throw new Exception(MessageConstants.S_EXISTS_LOCATION_FLOOR);

                        location = new Location
                        {
                            Id = Guid.NewGuid(),
                            WorkLocation = request.WorkLocation.ToUpper(),
                            Floor = request.Floor.ToUpper(),
                            IsActive = request.IsActive,

                            CreatedBy = currentUser,
                            CreatedAt = now,
                        };

                        _domainServices.InsertLocation(location);
                    }

                    _domainServices.SaveChanges();

                    result.Success = true;
                    result.Message = MessageConstants.S_SAVED_LOCATION_SUCCESS;

                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"method: SaveLocation(), " +
                        $"request: {request}, " +
                        $"message: {ex.Message}");
                    throw;
                }
            }).ConfigureAwait(false);
        }
    }
}
