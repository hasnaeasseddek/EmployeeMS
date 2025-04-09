using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Domain.DomainEntities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }

}
