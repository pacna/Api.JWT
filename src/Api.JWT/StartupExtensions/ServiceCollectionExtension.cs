using Api.JWT.Configurations;
using Api.JWT.Contexts;
using Api.JWT.Repositories;
using Api.JWT.Services;
using Api.JWT.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Api.JWT.StartupExtensions;

internal static class ServiceCollectionExtension
{
    internal static IServiceCollection AddCustomMediatR(this IServiceCollection services)
    {
        return services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(Program).Assembly));
    }

    internal static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
    {
        return services.AddSwaggerGen(options => 
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "API.JWT",
                Description = "A simple JWT (JSON Web Token) service"
            });
        });
    }

    internal static IServiceCollection AddContexts(this IServiceCollection services)
    {
        return services.AddDbContext<JWTContext>(options => options.UseInMemoryDatabase("test"));
    }

    internal static IServiceCollection AddSetting(this IServiceCollection services, ApplicationSetting setting)
    {
        return services.AddSingleton<IApplicationSetting>(setting);
    }

    internal static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddSingleton<IAuthenticationService, AuthenticationService>();
    }

    internal static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped<IJWTRepository, JWTRepository>();
    }

    internal static IServiceCollection AddControllerConvention(this IServiceCollection services)
    {
        services.AddControllersWithViews(options => 
        {
            options.Conventions.Add(new ControllerNamingConvention());
        });

        return services;
    }

    internal static IServiceCollection AddCustomControllers(this IServiceCollection services)
    {
        services.AddControllers();

        return services;
    }
}