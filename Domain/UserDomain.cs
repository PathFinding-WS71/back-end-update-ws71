using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace Domain;

public class UserDomain: IUserDomain
{
    private readonly IUserInfrastructure _userInfrastructure;
    private readonly IEncryptDomain _encryptDomain;
    private readonly ITokenDomain _tokenDomain;
    public UserDomain(IUserInfrastructure userInfrastructure,IEncryptDomain encryptDomain,ITokenDomain tokenDomain)
    {
        _userInfrastructure = userInfrastructure;
        _encryptDomain = encryptDomain;
        _tokenDomain = tokenDomain;
    }
    
    public async Task<string> Login(User user)
    {
        var foundUser = await _userInfrastructure.GetByUsername(user.Username);
        
        if (_encryptDomain.Ecnrypt(user.Password) == foundUser.Password)
        {
            return _tokenDomain.GenerateJwt(foundUser.Username);
        }

        throw new ArgumentException("Invalid username or password");
    }

    public async Task<int> Signup(User user)
    {
        user.Password = _encryptDomain.Ecnrypt(user.Password);
        return await _userInfrastructure.Signup(user);
    }

    public async Task<User> GetByUsername(string username)
    {
        return  await _userInfrastructure.GetByUsername(username);
    }
}