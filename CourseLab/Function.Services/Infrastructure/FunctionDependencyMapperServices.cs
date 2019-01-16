using Function.Data.Infrastructure;
using Function.Services.Services.Anouncement;
using Function.Services.Services.Schedule;
using Function.Services.Services.Subscription;
using Microsoft.Extensions.DependencyInjection;

namespace Function.Services.Infrastructure
{
    public static class FunctionDependencyMapperServices
    {
        public static IServiceCollection AddToContainer(this IServiceCollection services)
        {
            FunctionDependencyMapperData.AddToContainer(services);

            services.AddTransient(typeof(IScheduleService), typeof(ScheduleService));
            services.AddTransient(typeof(ISubscriptionService), typeof(SubscriptionService));
            services.AddTransient(typeof(IAnouncementService), typeof(AnouncementsService));
            return services;
        }
    }
}
