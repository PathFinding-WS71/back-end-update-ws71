using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class LocationInfrastructure : ILocationInfrastructure
{
    private readonly UpdateDbContext _updateDbContext;


    public LocationInfrastructure(UpdateDbContext updateDbContext)
    {
        _updateDbContext = updateDbContext;
    }

    public async Task<List<Location>> GetAll()
    {
        return await _updateDbContext.Locations.Where(location => location.IsActive).ToListAsync();
    }

    public async Task<Location> GetById(int id)
    {
        return await _updateDbContext.Locations.SingleAsync(location => location.IsActive && location.Id == id);
    }

    public async Task<bool> Create(Location locationData)
    {
        try
        {
            locationData.IsActive = true;
            await _updateDbContext.Locations.AddAsync(locationData);
            await _updateDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> Update(int id, Location locationData)
    {
        try
        {
            var location = await _updateDbContext.Locations.FindAsync(id);

            if (location == null)
                return false;
            
            location.LocationDescription = locationData.LocationDescription;
            location.LocationAddress = locationData.LocationAddress;
            location.LocationImageUrl = locationData.LocationImageUrl;

            _updateDbContext.Locations.Update(location);
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
        var location = await _updateDbContext.Locations.FindAsync(id);
        
        if (location == null)
            return false;
        
        location.IsActive = false;

        _updateDbContext.Locations.Update(location);
        await _updateDbContext.SaveChangesAsync();
        
        return true;    
    }
}