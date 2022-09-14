using CostaSoftware_CleanArchitecture.Application.Authentication.Commands.Register;
using CostaSoftware_CleanArchitecture.Application.Authentication.Common;
using CostaSoftware_CleanArchitecture.Application.Authentication.Queries.Login;
using CostaSoftware_CleanArchitecture.Contracts.Authentication;
using Mapster;

namespace CostaSoftware_CleanArchitecture.Api.Common.Mappings;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}
