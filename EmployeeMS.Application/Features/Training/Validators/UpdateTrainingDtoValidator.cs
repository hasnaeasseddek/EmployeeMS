using EmployeeMS.Shared.DTOs.Training;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.Training.Validators
{
    public class UpdateTrainingDtoValidator : AbstractValidator<UpdateTrainingDto>
    {
        public UpdateTrainingDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            Include(new ITrainingDtoValidator());
        }
    }
}
