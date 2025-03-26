using EmployeeMS.Shared.DTOs.Employee;
using FluentValidation;

namespace EmployeeMS.Application.Features.Employee.Validators
{
    public class IEmployeeDtoValidator : AbstractValidator<IEmployeeDto>
    {
        public IEmployeeDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.DepartmentId).GreaterThan(0);
            RuleFor(x => x.PositionId).GreaterThan(0);
            RuleFor(x => x.DateHired).NotEmpty();
        }
    }
}
