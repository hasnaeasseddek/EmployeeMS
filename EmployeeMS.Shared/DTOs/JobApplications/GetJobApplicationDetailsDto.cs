using EmployeeMS.Shared.DTOs.Common;
using EmployeeMS.Shared.DTOs.JobOffre;
using EmployeeMS.Shared.Enums;

namespace EmployeeMS.Shared.DTOs.JobApplications
{
    public class GetJobApplicationDetailsDto :BaseDTO
    {
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public string CurrentPosition { get; set; } = string.Empty;
        public string ExperienceLevel { get; set; } = string.Empty;
        public string Skills { get; set; } = string.Empty;

        public int JobOfferId { get; set; }
        public GetJobOfferDetailsDto? JobOfferDto { get; set; }

        public ApplicationStatus Status { get; set; }

        public DateTime ApplicationDate { get; set; }

        // Liste des fichiers joints (CV, lettre de motivation…)
        public List<string>? DocumentPaths { get; set; }
    }

}