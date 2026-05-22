namespace Bull.Ga.Common.DtoModels
{
    public class CompanyInputRequest
    {
        public Guid? Id { get; set;  }
        public string Code { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
