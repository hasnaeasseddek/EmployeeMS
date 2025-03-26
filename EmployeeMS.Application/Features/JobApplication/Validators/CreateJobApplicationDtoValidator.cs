using EmployeeMS.Shared.DTOs.JobApplication;
using FluentValidation;

namespace EmployeeMS.Application.Features.JobApplication.Validators
{
    public class CreateJobApplicationDtoValidator : AbstractValidator<CreateJobApplicationDto>
    {
        public CreateJobApplicationDtoValidator()
        {
            Include(new IJobApplicationDtoValidator());
        }
    }
}
