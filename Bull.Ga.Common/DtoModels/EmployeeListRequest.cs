namespace Bull.Ga.Common.DtoModels
{
    public class EmployeeListRequest : BasicListRequest
    {
        public string Nik { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
