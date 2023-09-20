using Infrastructure.Model;

namespace Infrastructure.Interfaces;

public interface IRoleInfrastructure
{
    Task<List<Role>> GetAll();
    public Task<Role> GetById(int id);
    Task<bool> Create(Role roleData);
    Task<bool> Update(int id, Role roleData);
    Task<bool> Delete(int id);
}