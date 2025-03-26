using EmployeeMS.Shared.DTOs.LeaveRequest;
using FluentValidation;

namespace EmployeeMS.Application.Features.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        public ILeaveRequestDtoValidator()
        {
            RuleFor(x => x.EmployeeId).GreaterThan(0);
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty().GreaterThanOrEqualTo(x => x.StartDate);
            RuleFor(x => x.LeaveType).NotEmpty();
        }
    }
}
