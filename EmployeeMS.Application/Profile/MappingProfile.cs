using EmployeeMS.Domain.DomainEntities;
using EmployeeMS.Shared.DTOs.JobOffre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile() { 
            CreateMap<JobOffer,GetListAllJobOfferDto>().ReverseMap();
            CreateMap<JobOffer,GetJobOfferDetailsDto>().ReverseMap();
            CreateMap<JobOffer,CreateJobOfferDto>().ReverseMap();
            CreateMap<JobOffer,UpdateJobOfferDto>().ReverseMap();
        }
    }
}
