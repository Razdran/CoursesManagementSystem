using Function.Data.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Function.Services.Infrastructure
{
    public static class FunctionDependencyMapperServices
    {
        public static IServiceCollection AddToContainer(this IServiceCollection services)
        {
            FunctionDependencyMapperData.AddToContainer(services);

            
            return services;
        }
    }
}
