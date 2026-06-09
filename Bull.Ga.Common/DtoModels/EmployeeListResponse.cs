using Bull.Ga.Data.Models;

namespace Bull.Ga.Common.DtoModels
{
    public class EmployeeListResponse : BasicListResponse
    {
        public string Nik { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public List<Employee>? Items { get; set; }
    }
}
