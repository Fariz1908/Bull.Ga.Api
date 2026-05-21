using Bull.Ga.Data.Models;

namespace Bull.Ga.Common.DtoModels
{
    public class LocationListResponse : BasicListResponse
    {
        public string WorkLocation { get; set; } = string.Empty;
        public string Floor { get; set; } = string.Empty;
        public List<Location>? Items { get; set; }
    }
}
