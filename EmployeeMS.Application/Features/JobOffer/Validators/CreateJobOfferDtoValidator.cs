using EmployeeMS.Shared.DTOs.JobOffre;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Features.JobOffer.Validators
{
    public class CreateJobOfferDtoValidator : AbstractValidator<CreateJobOfferDto>
    {
        public CreateJobOfferDtoValidator()
        {
            Include(new IJobOfferDtoValidator());
        }
    }
}
