using Bull.Ga.Common.DtoModels;

namespace Bull.Ga.Business.Interfaces
{
    public interface IDropdownServices
    {
        Task<List<DropdownResponse>> AssetCatgories(string? filter);
        Task<List<DropdownResponse>> Departments(string? filter);
        Task<List<DropdownResponse>> DepreciationMethods(string? filter);
        Task<List<DropdownResponse>> Locations(string? filter);
    }
}
