using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.DtoModels;

namespace Bull.Ga.Business.Interfaces
{
    public interface IDropdownFacades
    {
        Task<ResultBase<List<DropdownResponse>>> AssetCatgories(string? filter);
        Task<ResultBase<List<DropdownResponse>>> Companies(string? filter);
        Task<ResultBase<List<DropdownResponse>>> Departments(string? filter);
        Task<ResultBase<List<DropdownResponse>>> DepreciationMethods(string? filter);
        Task<ResultBase<List<DropdownResponse>>> Items(string? filter);
        Task<ResultBase<List<DropdownResponse>>> Locations(string? filter);
    }
}
