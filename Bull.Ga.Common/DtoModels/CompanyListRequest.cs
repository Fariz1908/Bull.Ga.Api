namespace Bull.Ga.Common.DtoModels
{
    public class CompanyListRequest : BasicListRequest
    {
        public string Code { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
    }
}
