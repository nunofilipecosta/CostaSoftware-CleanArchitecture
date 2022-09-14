using CostaSoftware_CleanArchitecture.Domain.Entities;

namespace CostaSoftware_CleanArchitecture.Application.Authentication.Common;
public record AuthenticationResult(User User, string Token);
