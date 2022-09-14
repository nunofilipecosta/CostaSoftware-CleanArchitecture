using CostaSoftware_CleanArchitecture.Application.Common.Interfaces.Authentication;
using CostaSoftware_CleanArchitecture.Application.Common.Interfaces.Services;
using CostaSoftware_CleanArchitecture.Infrastructure.Authentication;
using CostaSoftware_CleanArchitecture.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CostaSoftware_CleanArchitecture.Infrastructure.Persistence;
using CostaSoftware_CleanArchitecture.Application.Persistence;

namespace CostaSoftware_CleanArchitecture.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>( configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
