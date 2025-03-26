using EmployeeMS.Shared.DTOs.EmployeeTraining;
using FluentValidation;

namespace EmployeeMS.Application.Features.EmployeeTraining.Validators
{
    public class UpdateEmployeeTrainingDtoValidator : AbstractValidator<UpdateEmployeeTrainingDto>
    {
        public UpdateEmployeeTrainingDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            Include(new IEmployeeTrainingDtoValidator());
        }
    }
}
