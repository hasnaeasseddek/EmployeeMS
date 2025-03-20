using EmployeeMS.Shared.DTOs.JobApplication;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.JobApplication.Validators
{
    public class UpdateJobApplicationDtoValidator : AbstractValidator <UpdateJobApplicationDto>
    {
        public UpdateJobApplicationDtoValidator()
        {
            Include(new IJobApplicationDtoValidator());
        }
    }
}
