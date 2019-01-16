using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Function.Data.Infrastructure
{
    public static class FunctionDependencyMapperData
    {
        public static IServiceCollection AddToContainer(this IServiceCollection services)
        {
            services.AddDbContext<FunctionContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            return services;
        }
    }
}
