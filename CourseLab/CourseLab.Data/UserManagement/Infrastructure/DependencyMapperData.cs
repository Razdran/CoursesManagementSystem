using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CourseLab.Data.UserManagement.Infrastructure
{
    public static class DependencyMapperData
    {
        public static IServiceCollection AddToContainer(this IServiceCollection services)
        {
            services.AddDbContext<UserManagementContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            return services;
        }
    }
}