namespace Bull.Ga.Common.AppModels
{
    public class AssetCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int UsefulLifeYear { get; set; }
        public int IdDepreciationMethod { get; set; }
        public string DepreciationMethod { get; set; } = string.Empty;
        public int ResidualValue { get; set; }
        public bool IsActive { get; set; } = true;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
    }
}
