namespace Bull.Ga.Common.DtoModels
{
    public class LocationListRequest : BasicListRequest
    {
        public string WorkLocation { get; set; } = string.Empty;
        public string Floor { get; set; } = string.Empty;
    }
}
