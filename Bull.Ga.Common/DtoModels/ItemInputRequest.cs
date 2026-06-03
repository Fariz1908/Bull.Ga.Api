namespace Bull.Ga.Common.DtoModels
{
    public class ItemInputRequest
    {
        public Guid? Id { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int FidAssetCategory { get; set; }
        public bool IsActive { get; set; }
    }
}
