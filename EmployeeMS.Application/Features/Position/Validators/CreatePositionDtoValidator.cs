using EmployeeMS.Shared.DTOs.Position;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Position.Validators
{
    public class CreatePositionDtoValidator : AbstractValidator<CreatePositionDto>
    {
        public CreatePositionDtoValidator()
        {
            Include(new IPositionDtoValidator());
        }
    }
}
