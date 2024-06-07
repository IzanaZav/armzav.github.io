using Gradebook.Application.Interfaces;
using Gradebook.Domain.Entities;
using Gradebook.Infrastructure.Identity;
using Gradebook.Infrastructure.Persistence;
using Gradebook.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gradebook.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("GradebookConnectionString"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)))
            .AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<IAppUserRepository, AppUserRepository>();
        services.AddTransient<IStudentRepository, StudentRepository>();
        services.AddTransient<IGroupRepository, GroupRepository>();
        services.AddTransient<ISubjectRepository, SubjectRepository>();
        services.AddTransient<IGradeRepository, GradeRepository>();
        services.AddTransient<IAttendanceRepository, AttendanceRepository>();

        return services;
    }
}