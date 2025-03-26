using EmployeeMS.Shared.DTOs.Department;
using FluentValidation;

namespace EmployeeMS.Application.Features.Department.Validators
{
    public class CreateDepartmentDtoValidator : AbstractValidator<CreateDepartmentDto>
    {
        public CreateDepartmentDtoValidator()
        {
            Include(new IDepartmentDtoValidator());
        }
    }
}
