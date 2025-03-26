using EmployeeMS.Shared.DTOs.LeaveRequest;
using FluentValidation;

namespace EmployeeMS.Application.Features.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        public CreateLeaveRequestDtoValidator()
        {
            Include(new ILeaveRequestDtoValidator());
        }
    }
}
