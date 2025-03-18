using EmployeeMS.Shared.DTOs.JobOffre;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.JobOffer.Validators
{
    public class IJobOfferDtoValidator : AbstractValidator<IJobOfferDto>
    {
        public IJobOfferDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Le titre est obligatoire.")
                .Length(5, 100).WithMessage("Le titre doit contenir entre 5 et 100 caractères.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La description est obligatoire.")
                .Length(10, 1000).WithMessage("La description doit contenir entre 10 et 1000 caractères.");

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("L'emplacement est obligatoire.");

            RuleFor(x => x.EmploymentType)
                .NotEmpty().WithMessage("Le type d'emploi est obligatoire.");

            RuleFor(x => x.ExpirationDate)
                .NotNull().WithMessage("La date d'expiration est obligatoire.")
                .GreaterThan(DateTime.UtcNow).WithMessage("La date d'expiration doit être dans le futur.");

            //RuleFor(x => x.RecruitmentFileUrl)
            //    .NotEmpty().WithMessage("L'URL du fichier de recrutement est obligatoire.")
            //    .Must(BeAValidUrl).WithMessage("L'URL du fichier de recrutement n'est pas valide.");
        }

        //private bool BeAValidUrl(string url)
        //{
        //    return Uri.TryCreate(url, UriKind.Absolute, out _);
        //}
    }

}
