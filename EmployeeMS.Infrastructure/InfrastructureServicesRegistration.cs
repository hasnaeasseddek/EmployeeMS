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
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IJobOfferRepository, JobOfferRepository>();
            services.AddScoped<IInternshipApplicationRepository, InternshipApplicationRepository>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<IEmployeeTrainingRepository, EmployeeTrainingRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            return services;
        }
    }
}
