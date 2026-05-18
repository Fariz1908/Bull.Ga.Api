namespace Bull.Ga.Common.AppModels
{
    public class LocationLogDto
    {
        public Guid Id { get; set; }
        public string TransactionNo { get; set; }
        public DateOnly SubmittedDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
        public string? Location { get; set; }
        public string? Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
