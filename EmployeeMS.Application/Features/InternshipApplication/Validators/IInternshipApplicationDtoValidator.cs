using EmployeeMS.Shared.DTOs.InternshipApplications;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.InternshipApplication.Validators
{
    public class IInternshipApplicationDtoValidator :AbstractValidator<IInternshipApplicationDto>
    {
        public IInternshipApplicationDtoValidator()
        {
            RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Le nom est requis.")
            .MaximumLength(100).WithMessage("Le nom ne doit pas dépasser 100 caractères.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Le prénom est requis.")
                .MaximumLength(100).WithMessage("Le prénom ne doit pas dépasser 100 caractères.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("L'email est requis.")
                .EmailAddress().WithMessage("L'email est invalide.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Le numéro de téléphone est requis.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Le numéro de téléphone est invalide.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("La date de naissance est requise.")
                .LessThan(DateTime.Now).WithMessage("La date de naissance doit être dans le passé.");

            RuleFor(x => x.Institution)
                .NotEmpty().WithMessage("L'institution est requise.");

            RuleFor(x => x.EducationLevel)
                .NotEmpty().WithMessage("Le niveau d'éducation est requis.");

            RuleFor(x => x.Specialization)
                .NotEmpty().WithMessage("La spécialisation est requise.");

            RuleFor(x => x.InternshipType)
                .NotEmpty().WithMessage("Le type de stage est requis.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("La ville est requise.");

            RuleForEach(x => x.Documents).ChildRules(doc =>
            {
                doc.RuleFor(d => d.Length)
                    .LessThanOrEqualTo(5 * 1024 * 1024) // 5 MB max
                    .WithMessage("Le fichier ne doit pas dépasser 5MB.");

                doc.RuleFor(d => d.ContentType)
                    .Must(ct => ct == "application/pdf" || ct == "image/jpeg" || ct == "image/png")
                    .WithMessage("Seuls les fichiers PDF, JPG et PNG sont autorisés.");
            });
        }
    }
}
