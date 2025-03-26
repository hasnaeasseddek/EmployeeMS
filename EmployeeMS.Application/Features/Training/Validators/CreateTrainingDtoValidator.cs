using EmployeeMS.Shared.DTOs.Training;
using FluentValidation;

namespace EmployeeMS.Application.Features.Training.Validators
{
    public class CreateTrainingDtoValidator : AbstractValidator<CreateTrainingDto>
    {
        public CreateTrainingDtoValidator()
        {
            Include(new ITrainingDtoValidator());
        }
    }
}
