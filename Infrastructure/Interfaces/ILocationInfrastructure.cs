using Infrastructure.Model;

namespace Infrastructure.Interfaces;

public interface ILocationInfrastructure
{
    Task<List<Location>> GetAll();
    public Task<Location> GetById(int id);
    Task<bool> Create(Location locationData);
    Task<bool> Update(int id, Location locationData);
    Task<bool> Delete(int id);
}