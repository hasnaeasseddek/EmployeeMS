using EmployeeMS.Shared.DTOs.InternshipApplications;
using FluentValidation;

namespace EmployeeMS.Application.Features.InternshipApplication.Validators
{
    public class UpdateInternshipApplicationDtoValidator : AbstractValidator<UpdateInternshipApplicationDto>
    {
        public UpdateInternshipApplicationDtoValidator()
        {
            Include(new IInternshipApplicationDtoValidator());
        }
    }
}
