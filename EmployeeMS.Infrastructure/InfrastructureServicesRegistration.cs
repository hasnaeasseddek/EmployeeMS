using EmployeeMS.Application.Contracts.Persistence;
using EmployeeMS.Application.Interfaces;
using EmployeeMS.Infrastructure.Repositories;
using EmployeeMS.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeMS.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigurenInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeTrainingRepository, EmployeeTrainingRepository>();
            services.AddScoped<IInternshipApplicationRepository, InternshipApplicationRepository>();
            services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IJobOfferRepository, JobOfferRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
