using EmployeeMS.Shared.DTOs.Position;
using FluentValidation;

namespace EmployeeMS.Application.Features.Position.Validators
{
    public class IPositionDtoValidator : AbstractValidator<IPositionDto>
    {
        public IPositionDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Le titre est obligatoire.").Length(5, 100).WithMessage("Le titre doit contenir entre 5 et 100 caractères.");
            RuleFor(x => x.Description).MaximumLength(500);
            RuleFor(x => x.BaseSalary).GreaterThan(0);
        }
    }
}
