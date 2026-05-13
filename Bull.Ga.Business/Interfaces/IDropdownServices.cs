using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bull.Ga.Business.Interfaces
{
    public interface IDropdownServices
    {
        Task<List<DropdownResponse>> DepreciationMethods(string? filter);
    }
}
