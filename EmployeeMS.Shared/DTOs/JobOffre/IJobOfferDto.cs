using Microsoft.AspNetCore.Http;

namespace EmployeeMS.Shared.DTOs.JobOffre
{
    public interface IJobOfferDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string EmploymentType { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public IFormFile? AnnouncementFile { get; set; }
    }
}
