using EmployeeMS.Shared.DTOs.Common;

namespace EmployeeMS.Shared.DTOs.InternshipApplications
{
    public class GetInternshipApplicationDetailsDto : BaseDTO
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
        public DateTime ApplicationDate { get; set; }

        // Liste des URLs des documents au lieu de IFormFile
        public List<string>? DocumentUrls { get; set; }

        // Ajout du statut
        public string Status { get; set; } = string.Empty;
    }
}