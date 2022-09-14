using CostaSoftware_CleanArchitecture.Application.Authentication.Common;
using CostaSoftware_CleanArchitecture.Application.Common.Interfaces.Authentication;
using CostaSoftware_CleanArchitecture.Application.Persistence;
using CostaSoftware_CleanArchitecture.Domain.Entities;
using CostaSoftware_CleanArchitecture.Domain.Errors;
using ErrorOr;
using MediatR;

namespace CostaSoftware_CleanArchitecture.Application.Authentication.Commands.Register;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // check if user already exists
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            //throw new DuplicateEmailException("User with given email already exists");
            return Errors.User.DuplicateEmail;
        }

        // create a user ( generate unique id )
        var user = new User()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        // persist
        _userRepository.Add(user);

        // generate jwt toekn
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
