using EmployeeMS.Shared.DTOs.Employee;
using FluentValidation;

namespace EmployeeMS.Application.Features.Employee.Validators
{
    public class UpdateEmployeeDtoValidator : AbstractValidator<UpdateEmployeeDto>
    {
        public UpdateEmployeeDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            Include(new IEmployeeDtoValidator());
        }
    }
}
