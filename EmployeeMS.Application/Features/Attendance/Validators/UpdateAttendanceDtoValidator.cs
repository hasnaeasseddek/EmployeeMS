using EmployeeMS.Shared.DTOs.Attendance;
using FluentValidation;

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
