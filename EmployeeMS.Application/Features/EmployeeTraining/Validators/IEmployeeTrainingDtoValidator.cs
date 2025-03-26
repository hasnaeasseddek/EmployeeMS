using EmployeeMS.Shared.DTOs.EmployeeTraining;
using FluentValidation;

namespace EmployeeMS.Application.Features.EmployeeTraining.Validators
{
    public class IEmployeeTrainingDtoValidator : AbstractValidator<IEmployeeTrainingDto>
    {
        public IEmployeeTrainingDtoValidator()
        {
            RuleFor(x => x.EmployeeId).GreaterThan(0);
            RuleFor(x => x.TrainingId).GreaterThan(0);
            RuleFor(x => x.CertificationDate).NotEmpty();
        }
    }
}
