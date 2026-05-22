using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;

namespace Bull.Ga.Business.Facades
{
    public class DropdownFacades : IDropdownFacades
    {
        private readonly IDropdownServices _dropDownServices;

        public DropdownFacades(IDropdownServices dropdownServices)
        {
            _dropDownServices = dropdownServices;
        }

        public async Task<ResultBase<List<DropdownResponse>>> AssetCatgories(string? filter)
        {
            var result = await _dropDownServices.AssetCatgories(filter);

            if (result != null)
            {
                return new ResultBase<List<DropdownResponse>>
                {
                    Success = true,
                    Message = "Sukses",
                    Model = result
                };
            }

            var errorResponse = new ResultBase<List<DropdownResponse>>
            {
                Success = false,
                Message = "Data tidak ditemukan",
                Model = result
            };

            return errorResponse;
        }

        public async Task<ResultBase<List<DropdownResponse>>> Companies(string? filter)
        {
            var result = await _dropDownServices.Companies(filter);

            if (result != null)
            {
                return new ResultBase<List<DropdownResponse>>
                {
                    Success = true,
                    Message = "Sukses",
                    Model = result
                };
            }

            var errorResponse = new ResultBase<List<DropdownResponse>>
            {
                Success = false,
                Message = "Data tidak ditemukan",
                Model = result
            };

            return errorResponse;
        }

        public async Task<ResultBase<List<DropdownResponse>>> Departments(string? filter)
        {
            var result = await _dropDownServices.Departments(filter);

            if (result != null)
            {
                return new ResultBase<List<DropdownResponse>>
                {
                    Success = true,
                    Message = "Sukses",
                    Model = result
                };
            }

            var errorResponse = new ResultBase<List<DropdownResponse>>
            {
                Success = false,
                Message = "Data tidak ditemukan",
                Model = result
            };

            return errorResponse;
        }

        public async Task<ResultBase<List<DropdownResponse>>> DepreciationMethods(string? filter)
        {
            var result = await _dropDownServices.DepreciationMethods(filter);

            if (result != null)
            {
                return new ResultBase<List<DropdownResponse>>
                {
                    Success = true,
                    Message = "Sukses",
                    Model = result
                };
            }

            var errorResponse = new ResultBase<List<DropdownResponse>>
            {
                Success = false,
                Message = "Data tidak ditemukan",
                Model = result
            };

            return errorResponse;
        }

        public async Task<ResultBase<List<DropdownResponse>>> Locations(string? filter)
        {
            var result = await _dropDownServices.Locations(filter);

            if (result != null)
            {
                return new ResultBase<List<DropdownResponse>>
                {
                    Success = true,
                    Message = "Sukses",
                    Model = result
                };
            }

            var errorResponse = new ResultBase<List<DropdownResponse>>
            {
                Success = false,
                Message = "Data tidak ditemukan",
                Model = result
            };

            return errorResponse;
        }
    }
}
