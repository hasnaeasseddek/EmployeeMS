using EmployeeMS.Shared.DTOs.InternshipApplications;
using FluentValidation;

namespace EmployeeMS.Application.Features.InternshipApplication.Validators
{
    public class CreateInternshipApplicationDtoValidator : AbstractValidator<CreateInternshipApplicationDto>
    {
        public CreateInternshipApplicationDtoValidator()
        {
            Include(new IInternshipApplicationDtoValidator());
        }
    }
}
