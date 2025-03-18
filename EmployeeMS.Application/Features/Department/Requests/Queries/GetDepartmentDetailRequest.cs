﻿using EmployeeMS.Shared.DTOs.Department;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Department.Requests.Queries
{
    public class GetDepartmentDetailRequest : IRequest<GetDepartmentDetailsDto>
    {
        public int Id { get; set; }
    }
}
