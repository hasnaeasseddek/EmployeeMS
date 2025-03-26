using EmployeeMS.Shared.DTOs.Position;
using FluentValidation;

namespace EmployeeMS.Application.Features.Position.Validators
{
    public class CreatePositionDtoValidator : AbstractValidator<CreatePositionDto>
    {
        public CreatePositionDtoValidator()
        {
            Include(new IPositionDtoValidator());
        }
    }
}
