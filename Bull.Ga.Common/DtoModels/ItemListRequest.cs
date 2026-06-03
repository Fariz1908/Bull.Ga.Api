namespace Bull.Ga.Common.DtoModels
{
    public class ItemListRequest : BasicListRequest
    {
        public string? ItemName { get; set; } = string.Empty;
        public string? AssetCategoryName { get; set; } = string.Empty;
    }
}
