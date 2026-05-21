using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Data.Models;

namespace Bull.Ga.Business.Facades
{
    public class LocationFacades : ILocationFacades
    {
        private readonly ILocationServices _locationServices;

        public LocationFacades(ILocationServices locationServices) 
        {
            _locationServices = locationServices;
        }

        public async Task<ResultBase<LocationListResponse>> FindAllLocation(LocationListRequest request)
        {
            var result = await _locationServices.FindAllLocation(request);

            if (result != null)
            {
                return new ResultBase<LocationListResponse>
                {
                    Success = true,
                    Message = "Sukses",
                    Model = result
                };
            }

            var errorResponse = new ResultBase<LocationListResponse>
            {
                Success = false,
                Message = "Data tidak ditemukan",
                Model = result
            };

            return errorResponse;
        }

        public async Task<ResultBase<Location>> FindByIdLocation(Guid id)
        {
            var result = await _locationServices.FindByIdLocation(id);

            if (result != null)
            {
                return new ResultBase<Location>
                {
                    Success = true,
                    Message = "Sukses",
                    Model = result
                };
            }

            var errorResponse = new ResultBase<Location>
            {
                Success = false,
                Message = "Data tidak ditemukan",
                Model = result
            };

            return errorResponse;
        }

        public async Task<ResultBase> SaveLocation(LocationInputRequest request)
        {
            var result = await _locationServices.SaveLocation(request);

            return result;
        }
    }
}
