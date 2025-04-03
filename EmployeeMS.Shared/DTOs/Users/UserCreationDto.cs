using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.Users
{
    public class UserCreationDto
    {
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Enabled { get; set; } = true;
        public bool EmailVerified { get; set; } = true;
        public List<CredentialDto>? Credentials { get; set; }
    }
}
