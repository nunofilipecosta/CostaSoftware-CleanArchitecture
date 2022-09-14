using CostaSoftware_CleanArchitecture.Api.Common.Mappings;
using CostaSoftware_CleanArchitecture.Api.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CostaSoftware_CleanArchitecture.Api;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();

        services.AddControllers();

        //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
        services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
