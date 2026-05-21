using Bull.Ga.Common.AppModels;

namespace Bull.Ga.Common.DtoModels
{
    public class LocationLogListResponse : BasicListResponse
    {
        public Guid FidAsset { get; set; }
        public PagedList<LocationLogDto>? Items { get; set; }
    }
}
