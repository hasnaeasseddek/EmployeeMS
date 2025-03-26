using EmployeeMS.Shared.DTOs.Department;
using FluentValidation;

namespace EmployeeMS.Application.Features.Department.Validators
{
    public class UpdateDepartmentDtoValidator : AbstractValidator<UpdateDepartmentDto>
    {
        public UpdateDepartmentDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            Include(new IDepartmentDtoValidator());
        }
    }
}
