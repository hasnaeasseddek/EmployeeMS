using EmployeeMS.Shared.DTOs.Position;
using FluentValidation;

namespace EmployeeMS.Application.Features.Position.Validators
{
    public class UpdatePositionDtoValidator : AbstractValidator<UpdatePositionDto>
    {
        public UpdatePositionDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            Include(new IPositionDtoValidator());
        }
    }
}
