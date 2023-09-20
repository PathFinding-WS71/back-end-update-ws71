using Infrastructure.Model;

namespace Infrastructure.Interfaces;

public interface IUserInfrastructure
{
    Task<User> GetByUsername(string username);
    Task<int> Signup(User user);
}