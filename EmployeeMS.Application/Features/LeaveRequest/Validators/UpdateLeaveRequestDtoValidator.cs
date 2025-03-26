using EmployeeMS.Shared.DTOs.LeaveRequest;
using FluentValidation;

namespace EmployeeMS.Application.Features.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        public UpdateLeaveRequestDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            Include(new ILeaveRequestDtoValidator());
        }
    }
}
