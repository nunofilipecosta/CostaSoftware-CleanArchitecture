using CostaSoftware_CleanArchitecture.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CostaSoftware_CleanArchitecture.Application.Authentication.Commands.Register;
public record RegisterCommand (string FirstName, string LastName, string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>> ;

