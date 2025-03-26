using EmployeeMS.Shared.DTOs.JobOffre;
using FluentValidation;

namespace EmployeeMS.Application.Features.JobOffer.Validators
{
    public class UpdateJobOfferDtoValidator : AbstractValidator<UpdateJobOfferDto>
    {
        public UpdateJobOfferDtoValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("L'ID de l'offre est obligatoire.");
            Include(new IJobOfferDtoValidator());

        }
    }
}
