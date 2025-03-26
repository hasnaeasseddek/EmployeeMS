using EmployeeMS.Shared.DTOs.Employee;
using FluentValidation;

namespace EmployeeMS.Application.Features.Employee.Validators
{
    public class CreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeDtoValidator()
        {
            Include(new IEmployeeDtoValidator());
        }
    }
}
