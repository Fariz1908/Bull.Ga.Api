namespace Bull.Ga.Common.DtoModels
{
    public class LocationLogInputRequest
    {
        public Guid? Id { get; set; }
        public string TransactionNo { get; set; }
        public Guid FidAsset { get; set; }
        public DateOnly SubmittedDate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
    }
}
