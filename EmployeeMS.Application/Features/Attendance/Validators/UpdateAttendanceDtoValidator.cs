using EmployeeMS.Shared.DTOs.Attendance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Attendance.Validators
{
    public class UpdateAttendanceDtoValidator : AbstractValidator<UpdateAttendanceDto>
    {
        public UpdateAttendanceDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            Include(new IAttendanceDtoValidator());
        }
    }
}
