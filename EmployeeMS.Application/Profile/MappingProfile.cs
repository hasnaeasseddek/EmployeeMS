using EmployeeMS.Domain.DomainEntities;
using EmployeeMS.Shared.DTOs.Attendance;
using EmployeeMS.Shared.DTOs.Contract;
using EmployeeMS.Shared.DTOs.Department;
using EmployeeMS.Shared.DTOs.Employee;
using EmployeeMS.Shared.DTOs.EmployeeTraining;
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

            CreateMap<EmployeeTraining, CreateEmployeeTrainingDto>().ReverseMap();
            CreateMap<EmployeeTraining, UpdateEmployeeTrainingDto>().ReverseMap();
            
        }
    }
}
