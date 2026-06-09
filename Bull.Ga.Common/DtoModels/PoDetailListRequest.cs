namespace Bull.Ga.Common.DtoModels
{
    public class PoDetailListRequest : BasicListRequest
    {
        public string PrNo { get; set; } = string.Empty;
        public string PoNo { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Item {  get; set; } = string.Empty;
    }
}
