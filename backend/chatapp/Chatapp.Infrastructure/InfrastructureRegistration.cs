using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Chatapp.Infrastructure.Data;
using Chatapp.Core.Interfaces;
using Chatapp.Infrastructure.Repositories;
using Chatapp.Core.ServicesInterface;
using Chatapp.Infrastructure.Services;

namespace Chatapp.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IImageManagmentService, ImageManagmentService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<AppDbContext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }

    }

}
