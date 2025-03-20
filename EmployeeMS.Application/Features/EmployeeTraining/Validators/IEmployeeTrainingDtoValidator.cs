using EmployeeMS.Shared.DTOs.EmployeeTraining;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.EmployeeTraining.Validators
{
    public class IEmployeeTrainingDtoValidator : AbstractValidator<IEmployeeTrainingDto>
    {
        public IEmployeeTrainingDtoValidator()
        {
            RuleFor(x => x.EmployeeId).GreaterThan(0);
            RuleFor(x => x.TrainingId).GreaterThan(0);
            RuleFor(x => x.CertificationDate).NotEmpty();
        }
    }
}
