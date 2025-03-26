using EmployeeMS.Shared.DTOs.Contract;
using FluentValidation;

namespace EmployeeMS.Application.Features.Contract.Validators
{
    public class IContractDtoValidator : AbstractValidator<IContractDto>
    {
        public IContractDtoValidator()
        {
            RuleFor(x => x.EmployeeId).GreaterThan(0);
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.Salary).GreaterThan(0);
            RuleFor(x => x.ContractType).NotEmpty();
        }
    }
}
