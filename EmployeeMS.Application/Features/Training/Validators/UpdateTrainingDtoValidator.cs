using EmployeeMS.Shared.DTOs.Training;
using FluentValidation;

namespace EmployeeMS.Application.Features.Training.Validators
{
    public class UpdateTrainingDtoValidator : AbstractValidator<UpdateTrainingDto>
    {
        public UpdateTrainingDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            Include(new ITrainingDtoValidator());
        }
    }
}
