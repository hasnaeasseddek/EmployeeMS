using EmployeeMS.Shared.DTOs.Common;
using Microsoft.AspNetCore.Http;

namespace EmployeeMS.Shared.DTOs.JobOffre
{
    public class GetListAllJobOfferDto : BaseDTO
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public string ExpirationDate { get; set; }
        public string Description { get; set; }
        public IFormFile? AnnouncementFile { get; set; }
    }

}
