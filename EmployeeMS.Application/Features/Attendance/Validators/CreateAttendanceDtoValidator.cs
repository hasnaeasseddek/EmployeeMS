using EmployeeMS.Shared.DTOs.Attendance;
using FluentValidation;

namespace EmployeeMS.Application.Features.Attendance.Validators
{
    public class CreateAttendanceDtoValidator : AbstractValidator<CreateAttendanceDto>
    {
        public CreateAttendanceDtoValidator()
        {
            Include(new IAttendanceDtoValidator());
        }
    }
}
