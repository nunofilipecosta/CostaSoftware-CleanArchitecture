using CostaSoftware_CleanArchitecture.Domain.Entities;

namespace CostaSoftware_CleanArchitecture.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator
{
    string GenerateToken(User user); 

}
