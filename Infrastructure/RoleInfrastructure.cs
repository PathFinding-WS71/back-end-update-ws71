using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class RoleInfrastructure : IRoleInfrastructure
{
    private readonly UpdateDbContext _updateDbContext;

    public RoleInfrastructure(UpdateDbContext updateDbContext)
    {
        _updateDbContext = updateDbContext;
    }

    public async Task<List<Role>> GetAll()
    {
        return await _updateDbContext.Roles.Where(role => role.IsActive).ToListAsync();
    }

    public async Task<Role> GetById(int id)
    {
        return await _updateDbContext.Roles.SingleAsync(role => role.IsActive && role.Id == id);
    }

    public async Task<bool> Create(Role roleData)
    {
        try
        {
            roleData.IsActive = true;
            await _updateDbContext.Roles.AddAsync(roleData);
            await _updateDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> Update(int id, Role roleData)
    {
        try
        {
            var role = await _updateDbContext.Roles.FindAsync(id);

            if (role == null)
                return false;
            
            role.Name = roleData.Name;

            _updateDbContext.Roles.Update(role);
            await _updateDbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> Delete(int id)
    {
        var role = await _updateDbContext.Roles.FindAsync(id);

        if (role == null)
            return false;

        role.IsActive = false;

        _updateDbContext.Roles.Update(role);
        await _updateDbContext.SaveChangesAsync();
        
        return true;
    }
}