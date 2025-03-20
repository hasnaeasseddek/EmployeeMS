using EmployeeMS.Shared.DTOs.Attendance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Attendance.Validators
{
    public class IAttendanceDtoValidator : AbstractValidator<IAttendanceDto>
    {
        public IAttendanceDtoValidator()
        {
            RuleFor(x => x.EmployeeId).GreaterThan(0);
            RuleFor(x => x.CheckInTime).NotEmpty();
            RuleFor(x => x.HoursWorked).GreaterThanOrEqualTo(0);
        }
    }
}
