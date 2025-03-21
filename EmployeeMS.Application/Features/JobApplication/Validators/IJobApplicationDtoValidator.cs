using EmployeeMS.Shared.DTOs.JobApplications;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.JobApplication.Validators
{
    public class IJobApplicationDtoValidator : AbstractValidator<IJobApplicationDto>
    {
        public IJobApplicationDtoValidator()
        {
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Le nom est requis.")
                .MaximumLength(50).WithMessage("Le nom ne doit pas dépasser 50 caractères.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Le prénom est requis.")
                .MaximumLength(50).WithMessage("Le prénom ne doit pas dépasser 50 caractères.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("L'email est requis.")
                .EmailAddress().WithMessage("L'email est invalide.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Le numéro de téléphone est requis.")
                .Matches(@"^\+?\d{8,15}$").WithMessage("Le numéro de téléphone est invalide.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("La date de naissance est requise.")
                .Must(BeAValidAge).WithMessage("L'âge minimum requis est de 18 ans.");

            RuleFor(x => x.CurrentPosition)
                .NotEmpty().WithMessage("Le poste actuel est requis.")
                .MaximumLength(100).WithMessage("Le poste ne doit pas dépasser 100 caractères.");

            RuleFor(x => x.ExperienceLevel)
                .NotEmpty().WithMessage("Le niveau d'expérience est requis.");

            RuleFor(x => x.Skills)
                .NotEmpty().WithMessage("Les compétences sont requises.");

            RuleFor(x => x.JobOfferId)
                .GreaterThan(0).WithMessage("L'offre d'emploi sélectionnée est invalide.");


            RuleFor(x => x.Documents)
                .Must(files => files == null || files.Count <= 5)
                .WithMessage("Vous ne pouvez pas envoyer plus de 5 documents.");

            RuleForEach(x => x.Documents)
                .Must(file => file.Length <= 5 * 1024 * 1024) // Max 5 Mo par fichier
                .WithMessage("Chaque document ne doit pas dépasser 5 Mo.")
                .Must(file => IsValidFileType(file.FileName))
                .WithMessage("Seuls les fichiers PDF, DOCX et PNG/JPG sont acceptés.");
        }

        private bool BeAValidAge(DateTime date)
        {
            return date <= DateTime.UtcNow.AddYears(-18); // Minimum 18 ans
        }

        private bool IsValidFileType(string fileName)
        {
            var allowedExtensions = new[] { ".pdf", ".docx", ".png", ".jpg", ".jpeg" };
            var fileExtension = System.IO.Path.GetExtension(fileName).ToLower();
            return allowedExtensions.Contains(fileExtension);
        }
    }
}

