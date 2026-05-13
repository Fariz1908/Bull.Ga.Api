using Bull.Ga.Business.Interfaces;
using Bull.Ga.Business.Modules;
using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bull.Ga.Business.Facades
{
    public class DropdownFacades : IDropdownFacades
    {
        private readonly IDropdownServices _dropDownServices;

        public DropdownFacades(IDropdownServices dropdownServices)
        {
            _dropDownServices = dropdownServices;
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
    }
}
