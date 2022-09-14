using CostaSoftware_CleanArchitecture.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CostaSoftware_CleanArchitecture.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;