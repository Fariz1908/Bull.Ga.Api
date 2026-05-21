namespace Bull.Ga.Common.DtoModels
{
    public class LocationInputRequest
    {
        public Guid? Id { get; set; }
        public required string WorkLocation { get; set; }
        public string Floor { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
