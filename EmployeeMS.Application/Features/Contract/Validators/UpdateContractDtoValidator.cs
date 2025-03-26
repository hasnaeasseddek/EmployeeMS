using EmployeeMS.Shared.DTOs.Contract;
using FluentValidation;

namespace EmployeeMS.Application.Features.Contract.Validators
{
    public class UpdateContractDtoValidator : AbstractValidator<UpdateContractDto>
    {
        public UpdateContractDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            Include(new IContractDtoValidator());
        }
    }
}
