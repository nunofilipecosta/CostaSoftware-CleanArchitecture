using CostaSoftware_CleanArchitecture.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using MediatR;
using CostaSoftware_CleanArchitecture.Application.Authentication.Commands.Register;
using CostaSoftware_CleanArchitecture.Application.Authentication.Common;
using CostaSoftware_CleanArchitecture.Application.Authentication.Queries.Login;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;

namespace CostaSoftware_CleanArchitecture.Api.Controllers;
[Route("api/auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;


    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost, Route("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authenticationResult = await _mediator.Send(command);


        var result = authenticationResult.Match(
            success => Ok(_mapper.Map<AuthenticationResult>(authenticationResult.Value)),
            failure => Problem(failure));

        return result;
    }

    [HttpPost, Route("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var loginQuery = _mapper.Map<LoginQuery>(request);
        var authenticationResult = await _mediator.Send(loginQuery);

        return authenticationResult.Match(
           success => Ok(_mapper.Map<AuthenticationResult>(authenticationResult.Value)),
           failure => Problem(failure));
    }
}
