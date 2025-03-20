using EmployeeMS.Shared.Enums;
using Microsoft.AspNetCore.Http;

namespace EmployeeMS.Domain.DomainEntities
{
    public class InternshipApplication : BaseDomainEntity
    {
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Institution { get; set; } = string.Empty;
        public string EducationLevel { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string InternshipType { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
        public List<string>? DocumentUrls { get; set; }
    }
}