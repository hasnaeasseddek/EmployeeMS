using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigurenInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("Connection")));
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeTrainingRepository, EmployeeTrainingRepository>();
            services.AddScoped<IInternshipApplicationRepository, InternshipApplicationRepository>();
            services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
            services.AddScoped<IJobOfferRepository, JobOfferRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            
            return services;
        }
    }
}
