using CostaSoftware_CleanArchitecture.Application.Authentication.Common;
using CostaSoftware_CleanArchitecture.Application.Common.Interfaces.Authentication;
using CostaSoftware_CleanArchitecture.Application.Persistence;
using CostaSoftware_CleanArchitecture.Domain.Entities;
using CostaSoftware_CleanArchitecture.Domain.Errors;
using ErrorOr;
using MediatR;

namespace CostaSoftware_CleanArchitecture.Application.Authentication.Queries.Login;
public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            //throw new Exception("User with given email does not exists");
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != query.Password)
        {
            //throw new Exception("Invalid password");
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
