using Bull.Ga.Data.Models;

namespace Bull.Ga.Common.DtoModels
{
    public class DepartmentListResponse : BasicListResponse
    {
        public string Code { get; set; } = string.Empty;
        public string DeptName { get; set; } = string.Empty;

        public List<Department>? Items { get; set; }
    }
}
