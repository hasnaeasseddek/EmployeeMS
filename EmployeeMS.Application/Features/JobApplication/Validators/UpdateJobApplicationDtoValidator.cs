using EmployeeMS.Shared.DTOs.JobApplication;
using FluentValidation;

namespace EmployeeMS.Application.Features.JobApplication.Validators
{
    public class UpdateJobApplicationDtoValidator : AbstractValidator<UpdateJobApplicationDto>
    {
        public UpdateJobApplicationDtoValidator()
        {
            Include(new IJobApplicationDtoValidator());
        }
    }
}
