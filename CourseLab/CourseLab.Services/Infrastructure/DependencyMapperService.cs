using CourseLab.Data.UserManagement.Infrastructure;
using CourseLab.Services.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace CourseLab.Services.Infrastructure
{
    public static class DependencyMapperService
    {
        public static IServiceCollection AddToContainer(this IServiceCollection services)
        {
            DependencyMapperData.AddToContainer(services);

            services.AddTransient(typeof(IUserService), typeof(UserService));

            return services;
        }
    }
}
