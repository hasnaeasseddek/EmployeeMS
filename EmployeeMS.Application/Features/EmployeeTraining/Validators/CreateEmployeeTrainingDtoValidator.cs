using EmployeeMS.Shared.DTOs.EmployeeTraining;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.EmployeeTraining.Validators
{
    public class CreateEmployeeTrainingDtoValidator : AbstractValidator<CreateEmployeeTrainingDto>
    {
        public CreateEmployeeTrainingDtoValidator()
        {
            Include(new IEmployeeTrainingDtoValidator());
        }
    }
}
