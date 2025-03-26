namespace EmployeeMS.Shared.DTOs.Department
{
    public class CreateDepartmentDto : IDepartmentDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
