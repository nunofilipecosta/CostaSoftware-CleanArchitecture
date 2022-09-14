using CostaSoftware_CleanArchitecture.Application.Persistence;
using CostaSoftware_CleanArchitecture.Domain.Entities;

namespace CostaSoftware_CleanArchitecture.Infrastructure.Persistence;
public class UserRepository : IUserRepository
{
    private readonly static List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }
}
