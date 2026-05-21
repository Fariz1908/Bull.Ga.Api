namespace Bull.Ga.Common.DtoModels
{
    public class DepartmentListRequest : BasicListRequest
    {
        public string Code { get; set; } = string.Empty;
        public string DeptName { get; set; } = string.Empty;
    }
}
