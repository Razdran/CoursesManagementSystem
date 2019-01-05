using CourseLab.Data.UserManagement.Infrastructure;
using CourseLab.Services.Services.Group;
using CourseLab.Services.Services.Objects;
using CourseLab.Services.Services.Professor;
using CourseLab.Services.Services.Student;
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
            services.AddTransient(typeof(IStudentService), typeof(StudentService));
            services.AddTransient(typeof(IProfessorService), typeof(ProfessorService));
            services.AddTransient(typeof(IGroupService), typeof(GroupService));
            services.AddTransient(typeof(IObjectService), typeof(ObjectService));
            return services;
        }
    }
}
