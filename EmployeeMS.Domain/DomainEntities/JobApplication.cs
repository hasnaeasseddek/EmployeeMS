using EmployeeMS.Shared.Enums;

namespace EmployeeMS.Domain.DomainEntities
{
    public class JobApplication : BaseDomainEntity
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

        public JobOffer JobOffer { get; set; }

        public List<string>? DocumentPaths { get; set; }
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;

    }
}