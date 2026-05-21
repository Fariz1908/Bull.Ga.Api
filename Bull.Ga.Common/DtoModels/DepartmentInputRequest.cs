namespace Bull.Ga.Common.DtoModels
{
    public class DepartmentInputRequest
    {
        public Guid? Id { get; set; }
        public required string Code { get; set; }
        public required string DeptName { get; set; }
        public bool IsActive { get; set; }
    }
}
