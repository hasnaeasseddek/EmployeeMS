using EmployeeMS.Shared.DTOs.Contract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
