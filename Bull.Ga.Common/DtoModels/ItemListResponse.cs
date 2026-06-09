using Bull.Ga.Common.AppModels;

namespace Bull.Ga.Common.DtoModels
{
    public class ItemListResponse : BasicListResponse
    {
        public string? ItemName { get; set; } = string.Empty;
        public string? AssetCategoryName { get; set; } = string.Empty;
        public List<ItemDto>? Items { get; set; }
    }
}
