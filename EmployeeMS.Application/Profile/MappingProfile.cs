using EmployeeMS.Domain.DomainEntities;
using EmployeeMS.Shared.DTOs.Attendance;
using EmployeeMS.Shared.DTOs.Contract;
using EmployeeMS.Shared.DTOs.Department;
using EmployeeMS.Shared.DTOs.Employee;
using EmployeeMS.Shared.DTOs.EmployeeTraining;
using EmployeeMS.Shared.DTOs.InternshipApplications;
using EmployeeMS.Shared.DTOs.JobApplication;
using EmployeeMS.Shared.DTOs.JobApplications;
using EmployeeMS.Shared.DTOs.JobOffre;
using EmployeeMS.Shared.DTOs.LeaveRequest;
using EmployeeMS.Shared.DTOs.Position;
using EmployeeMS.Shared.DTOs.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Application.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            // JobOffer mappings
            CreateMap<JobOffer, GetListAllJobOfferDto>().ReverseMap();
            CreateMap<JobOffer, GetJobOfferDetailsDto>().ReverseMap();
            CreateMap<JobOffer, CreateJobOfferDto>().ReverseMap();
            CreateMap<JobOffer, UpdateJobOfferDto>().ReverseMap();

            // Employee mappings
            CreateMap<Employee, GetListAllEmployeeDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.PositionTitle, opt => opt.MapFrom(src => src.Position.Title))
                .ReverseMap();

            CreateMap<Employee, GetEmployeeDetailsDto>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.PositionTitle, opt => opt.MapFrom(src => src.Position.Title))
                .ReverseMap();

            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();

            // Department mappings
            CreateMap<Department, GetListAllDepartmentDto>()
                .ForMember(dest => dest.EmployeeCount, opt => opt.MapFrom(src => src.Employees.Count))
                .ReverseMap();

            CreateMap<Department, GetDepartmentDetailsDto>()
                .ForMember(dest => dest.EmployeeCount, opt => opt.MapFrom(src => src.Employees.Count))
                .ReverseMap();

            CreateMap<Department, CreateDepartmentDto>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDto>().ReverseMap();

            // Position mappings
            CreateMap<Position, GetListAllPositionDto>()
                .ForMember(dest => dest.NumberOfEmployees, opt => opt.MapFrom(src => src.Employees.Count))
                .ReverseMap();

            CreateMap<Position, GetPositionDetailsDto>()
                .ForMember(dest => dest.NumberOfEmployees, opt => opt.MapFrom(src => src.Employees.Count))
                .ReverseMap();

            CreateMap<Position, CreatePositionDto>().ReverseMap();
            CreateMap<Position, UpdatePositionDto>().ReverseMap();

            // Contract mappings
            CreateMap<Contract, GetListAllContractDto>()
                .ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"))
                .ReverseMap();

            CreateMap<Contract, GetContractDetailsDto>()
                .ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"))
                .ReverseMap();

            CreateMap<Contract, CreateContractDto>().ReverseMap();
            CreateMap<Contract, UpdateContractDto>().ReverseMap();

            // Attendance mappings
            CreateMap<Attendance, GetListAllAttendanceDto>()
                .ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"))
                .ReverseMap();

            CreateMap<Attendance, GetAttendanceDetailsDto>()
                .ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"))
                .ReverseMap();

            CreateMap<Attendance, CreateAttendanceDto>().ReverseMap();
            CreateMap<Attendance, UpdateAttendanceDto>().ReverseMap();

            // LeaveRequest mappings
            CreateMap<LeaveRequest, GetListAllLeaveRequestDto>()
                .ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"))
                .ReverseMap();

            CreateMap<LeaveRequest, GetLeaveRequestDetailsDto>()
                .ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"))
                .ReverseMap();

            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();


            // Training mappings
            CreateMap<Training, GetListAllTrainingDto>()
                .ForMember(dest => dest.ParticipantCount, opt => opt.MapFrom(src => src.Participants.Count))
                .ReverseMap();

            CreateMap<Training, GetTrainingDetailsDto>()
                .ForMember(dest => dest.ParticipantCount, opt => opt.MapFrom(src => src.Participants.Count))
                .ReverseMap();

            CreateMap<Training, CreateTrainingDto>().ReverseMap();
            CreateMap<Training, UpdateTrainingDto>().ReverseMap();

            // EmployeeTraining mappings
            CreateMap<EmployeeTraining, GetListAllEmployeeTrainingDto>()
                .ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"))
                .ForMember(dest => dest.TrainingTitle, opt => opt.MapFrom(src => src.Training.Title))
                .ReverseMap();

            CreateMap<EmployeeTraining, GetEmployeeTrainingDetailsDto>()
                .ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"))
                .ForMember(dest => dest.TrainingTitle, opt => opt.MapFrom(src => src.Training.Title))
                .ReverseMap();

            // Mapping de CreateInternshipApplicationDto vers InternshipApplication
            CreateMap<CreateInternshipApplicationDto, InternshipApplication>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "En attente"))
                .ForMember(dest => dest.DocumentUrls, opt => opt.Ignore())// Les fichiers ne sont pas mappés directement
                .ReverseMap();


            // Mapping de InternshipApplication vers GetAllInternshipApplicationsDto
            CreateMap<InternshipApplication, GetAllInternshipApplicationsDto>()
                .ForMember(dest => dest.ApplicationDate, opt => opt.MapFrom(src => src.DateCreated));

            // Mapping de InternshipApplication vers GetInternshipApplicationDetailsDto
            CreateMap<InternshipApplication, GetInternshipApplicationDetailsDto>()
                .ForMember(dest => dest.ApplicationDate, opt => opt.MapFrom(src => src.DateCreated));

            // Mapping de UpdateInternshipApplicationDto vers InternshipApplication
            CreateMap<UpdateInternshipApplicationDto, InternshipApplication>()
                .ForMember(dest => dest.DocumentUrls, opt => opt.Ignore()); // On ne met pas à jour directement les fichiers

            //jobapplicationDtos

            // Mapping CreateJobApplicationDto -> JobApplication
            CreateMap<CreateJobApplicationDto, JobApplication>()
                .ForMember(dest => dest.DocumentPaths, opt => opt.Ignore());// Géré séparément

            // Mapping UpdateJobApplicationDto -> JobApplication
            CreateMap<UpdateJobApplicationDto, JobApplication>()
                .ForMember(dest => dest.DocumentPaths, opt => opt.Ignore());// Géré séparément

            // Mapping JobApplication -> GetJobApplicationDetailsDto
            CreateMap<JobApplication, GetJobApplicationDetailsDto>()
                .ForMember(dest => dest.JobOfferDto, opt => opt.MapFrom(src => src.JobOffer))
                .ForMember(dest => dest.DocumentPaths, opt => opt.MapFrom(src => src.DocumentPaths));

            // Mapping JobApplication -> GetAllJobApplicationsDto
            CreateMap<JobApplication, GetAllJobApplicationsDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.JobOfferTitle, opt => opt.MapFrom(src => src.JobOffer.Title));
        }
    }
}
