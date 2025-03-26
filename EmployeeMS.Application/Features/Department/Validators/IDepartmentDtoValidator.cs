using EmployeeMS.Shared.DTOs.Department;
using FluentValidation;

namespace EmployeeMS.Application.Features.Department.Validators
{
    public class IDepartmentDtoValidator : AbstractValidator<IDepartmentDto>
    {
        public IDepartmentDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(500);
        }
    }
}
