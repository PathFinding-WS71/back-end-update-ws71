using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class UserInfrastructure: IUserInfrastructure
{
    private readonly UpdateDbContext _updateDbContext;

    public UserInfrastructure(UpdateDbContext updateDbContext)
    {
        _updateDbContext = updateDbContext;
    }

    public async Task<User> GetByUsername(string username)
    {
        return await _updateDbContext.Users.SingleAsync(u => u.Username == username);
    }

    public async Task<int> Signup(User user)
    {
        user.DateCreated=DateTime.Now;
        _updateDbContext.Users.Add(user);
        await _updateDbContext.SaveChangesAsync();
        return user.Id;
    }
    
}