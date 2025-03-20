using EmployeeMS.Shared.DTOs.Common;
using EmployeeMS.Shared.Enums;

namespace EmployeeMS.Shared.DTOs.JobApplication
{
    public class GetAllJobApplicationsDto : BaseDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public ApplicationStatus Status { get; set; }

        // Nom de l'offre d'emploi associée
        public string JobOfferTitle { get; set; } = string.Empty;

        public DateTime ApplicationDate { get; set; }
    }
}