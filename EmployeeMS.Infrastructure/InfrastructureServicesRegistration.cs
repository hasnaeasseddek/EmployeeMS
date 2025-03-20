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
            services.AddScoped<IJobOfferRepository, JobOfferRepository>();
            services.AddScoped<IInternshipApplicationRepository, InternshipApplicationRepository>();
            return services;
        }
    }
}
