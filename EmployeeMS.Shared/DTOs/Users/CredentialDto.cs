using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.Users
{
    public class CredentialDto
    {
        public string Type { get; set; } = "password";
        public string Value { get; set; } = string.Empty;
        public bool Temporary { get; set; } = false;
    }
}
