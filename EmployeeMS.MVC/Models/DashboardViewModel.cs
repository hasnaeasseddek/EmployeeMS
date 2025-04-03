using EmployeeMS.Shared.DTOs.Users;

namespace EmployeeMS.MVC.Models
{
    public class DashboardViewModel
    {
        public int TotalUsers { get; set; }
        public int AdminsCount { get; set; }
        public int EmployeesCount { get; set; }
        public int VisitorsCount { get; set; }
        public List<KeycloakUser> Users { get; set; }
    }
}
