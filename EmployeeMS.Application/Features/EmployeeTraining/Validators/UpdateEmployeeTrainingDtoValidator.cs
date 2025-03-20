using EmployeeMS.Shared.DTOs.EmployeeTraining;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.EmployeeTraining.Validators
{
    public class UpdateEmployeeTrainingDtoValidator : AbstractValidator<UpdateEmployeeTrainingDto>
    {
        public UpdateEmployeeTrainingDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            Include(new IEmployeeTrainingDtoValidator());
        }
    }
}
