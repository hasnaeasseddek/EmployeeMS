using EmployeeMS.Shared.DTOs.EmployeeTraining;
using FluentValidation;

namespace EmployeeMS.Application.Features.EmployeeTraining.Validators
{
    public class CreateEmployeeTrainingDtoValidator : AbstractValidator<CreateEmployeeTrainingDto>
    {
        public CreateEmployeeTrainingDtoValidator()
        {
            Include(new IEmployeeTrainingDtoValidator());
        }
    }
}
