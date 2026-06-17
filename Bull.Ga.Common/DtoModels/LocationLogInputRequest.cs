namespace Bull.Ga.Common.DtoModels
{
    public class LocationLogInputRequest
    {
        public Guid? Id { get; set; }
        public string TransactionNo { get; set; }
        public Guid FidAsset { get; set; }
        public DateOnly SubmittedDate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public Guid FidLocation { get; set; }
        public int? FidEmployee { get; set; }
        public string Remarks { get; set; } = string.Empty;
    }
}
