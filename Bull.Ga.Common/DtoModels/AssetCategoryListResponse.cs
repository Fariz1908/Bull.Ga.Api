using Bull.Ga.Common.AppModels;

namespace Bull.Ga.Common.DtoModels
{
    public class AssetCategoryListResponse : BasicListResponse
    {
        public string CategoryName { get; set; } = string.Empty;
        public PagedList<AssetCategoryDto>? Items { get; set; }
    }
}
