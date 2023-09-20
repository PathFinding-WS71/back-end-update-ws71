using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace Domain;

public class LocationDomain : ILocationDomain
{
    private readonly ILocationInfrastructure _locationInfrastructure;

    public LocationDomain(ILocationInfrastructure locationInfrastructure)
    {
        _locationInfrastructure = locationInfrastructure;
    }

    public async Task<List<Location>> GetAll()
    {
        return await _locationInfrastructure.GetAll();
    }

    public async Task<Location> GetById(int id)
    {
        return await _locationInfrastructure.GetById(id);
    }

    public async Task<bool> Create(Location locationData)
    {
        return await _locationInfrastructure.Create(locationData);
    }

    public async Task<bool> Update(int id, Location locationData)
    {
        return await _locationInfrastructure.Update(id, locationData);
    }

    public async Task<bool> Delete(int id)
    {
        return await _locationInfrastructure.Delete(id);
    }
}