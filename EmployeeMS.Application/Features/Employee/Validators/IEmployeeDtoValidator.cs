using EmployeeMS.Shared.DTOs.Employee;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
