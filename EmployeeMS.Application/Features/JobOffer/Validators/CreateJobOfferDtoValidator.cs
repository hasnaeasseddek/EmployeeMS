using EmployeeMS.Shared.DTOs.JobOffre;
using FluentValidation;

namespace EmployeeMS.Application.Features.JobOffer.Validators
{
    public class CreateJobOfferDtoValidator : AbstractValidator<CreateJobOfferDto>
    {
        public CreateJobOfferDtoValidator()
        {
            Include(new IJobOfferDtoValidator());
        }
    }
}
