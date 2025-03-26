using EmployeeMS.Shared.DTOs.Training;
using FluentValidation;

namespace EmployeeMS.Application.Features.Training.Validators
{
    public class ITrainingDtoValidator : AbstractValidator<ITrainingDto>
    {
        public ITrainingDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(150);
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(x => x.StartDate);
        }
    }
}
