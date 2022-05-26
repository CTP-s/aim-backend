using aim_backend.Mappings;
using aim_backend.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace aim_backend.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IDisciplineService, DisciplineService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IFacultyService, FacultyService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICurriculumService, CurriculumService>();

            return services;
        }

        public static IServiceCollection AddMappingServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(UserMappings));

            return services;
        }
    }
}