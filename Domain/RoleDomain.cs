using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace Domain;

public class RoleDomain : IRoleDomain
{
    private readonly IRoleInfrastructure _roleInfrastructure;

    public RoleDomain(IRoleInfrastructure roleInfrastructure)
    {
        _roleInfrastructure = roleInfrastructure;
    }

    public async Task<List<Role>> GetAll()
    {
        return await _roleInfrastructure.GetAll();
    }

    public async Task<Role> GetById(int id)
    {
        return await _roleInfrastructure.GetById(id);
    }

    public async Task<bool> Create(Role roleData)
    {
        return await _roleInfrastructure.Create(roleData);
    }

    public async Task<bool> Update(int id, Role roleData)
    {
        return await _roleInfrastructure.Update(id, roleData);
    }

    public async Task<bool> Delete(int id)
    {
        return await _roleInfrastructure.Delete(id);
    }
}