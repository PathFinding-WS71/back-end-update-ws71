using Infrastructure.Model;

namespace Domain.Interfaces;

public interface IRoleDomain
{
    Task<List<Role>> GetAll();
    public Task<Role> GetById(int id);
    Task<bool> Create(Role roleData); 
    Task<bool> Update(int id, Role roleData );
    Task<bool> Delete(int id);
}