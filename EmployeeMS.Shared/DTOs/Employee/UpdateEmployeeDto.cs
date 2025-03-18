﻿using EmployeeMS.Shared.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Shared.DTOs.Employee
{
    public class UpdateEmployeeDto :BaseDTO, IEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public DateTime DateHired { get; set; }
    }
}
