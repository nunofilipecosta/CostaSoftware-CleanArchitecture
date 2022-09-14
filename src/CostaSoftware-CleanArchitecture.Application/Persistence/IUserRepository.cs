using CostaSoftware_CleanArchitecture.Domain.Entities;

namespace CostaSoftware_CleanArchitecture.Application.Persistence;
public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
