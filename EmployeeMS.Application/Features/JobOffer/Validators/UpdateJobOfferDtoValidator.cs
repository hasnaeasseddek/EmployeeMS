using EmployeeMS.Shared.DTOs.JobOffre;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
