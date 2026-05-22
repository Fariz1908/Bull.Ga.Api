using Bull.Ga.Data.Models;

namespace Bull.Ga.Common.DtoModels
{
    public class CompanyListResponse : BasicListResponse
    {
        public string Code { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;

        public List<Company>? Items { get; set; }
    }
}
