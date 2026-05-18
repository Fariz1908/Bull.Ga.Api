namespace Bull.Ga.Common.DtoModels
{
    public class AssetCategoryInputRequest
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int UsefulLifeYear { get; set; }
        public int IdDepreciationMethod { get; set; }
        public string DepreciationMethod { get; set; } = string.Empty;
        public int ResidualValue { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
