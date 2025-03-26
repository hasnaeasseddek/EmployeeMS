using EmployeeMS.Shared.DTOs.Contract;
using FluentValidation;

namespace EmployeeMS.Application.Features.Contract.Validators
{
    public class CreateContractDtoValidator : AbstractValidator<CreateContractDto>
    {
        public CreateContractDtoValidator()
        {
            Include(new IContractDtoValidator());
        }
    }
}
