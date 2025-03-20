﻿using EmployeeMS.Shared.DTOs.InternshipApplications;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.InternshipApplication.Validators
{
    public class CreateInternshipApplicationDtoValidator :AbstractValidator<CreateInternshipApplicationDto>
    {
        public CreateInternshipApplicationDtoValidator()
        {
            Include(new IInternshipApplicationDtoValidator());
        }
    }
}
