namespace Bull.Ga.Common.AppModels
{
    public class PoDetailDto
    {
        public Guid Id { get; set; }
        public string PrNo { get; set; } = string.Empty;
        public string PoNo { get; set; } = string.Empty;
        public string PoIdNo { get; set; } = string.Empty;
        public string PoTitle { get; set; } = string.Empty;
        public DateOnly DeliveredDate { get; set; }
        public DateOnly DueDate { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Item { get; set; } = string.Empty;
        public int Qty { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int UnitPrice { get; set; }
        public int Discount { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? CreatedDate { get; set; }
    }
}
