using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ActivityInfrastructure : IActivityInfrastructure
{
    private readonly UpdateDbContext _updateDbContext;

    public ActivityInfrastructure(UpdateDbContext updateDbContext)
    {
        _updateDbContext = updateDbContext;
    }

    public async Task<List<Activity>> GetAll()
    {
        return await _updateDbContext.Activities.Where(activity => activity.IsActive).ToListAsync();
    }
    public async Task<Activity> GetById(int id)
    {
        return await _updateDbContext.Activities.SingleAsync(activity => activity.IsActive && activity.Id == id);
    }
    public async Task<bool> Create(Activity activityData)
    {
        try
        {
            activityData.IsActive = true;

            await _updateDbContext.Activities.AddAsync(activityData);
            await _updateDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            return false;
        }
    }

    public async Task<bool> Update(int id, Activity activityData)
    {
        try
        {
            var activity = await _updateDbContext.Activities.FindAsync(id); //obtengo

            if (activity == null)
                return false;
            
            activity.ActivityTitle = activityData.ActivityTitle;
            activity.ActivityDescription = activityData.ActivityDescription;
            activity.ActivityDate = activityData.ActivityDate;
            activity.ActivityType = activityData.ActivityType;
            activity.LocationId = activityData.LocationId;

            _updateDbContext.Activities.Update(activity); //modifico
            await _updateDbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public async Task<bool> Delete(int id)
    {
        var activity = await _updateDbContext.Activities.FindAsync(id); //obtengo

        if (activity == null)
            return false;
        
        activity.IsActive = false;
        
        _updateDbContext.Activities.Update(activity); //modifico
        
        await _updateDbContext.SaveChangesAsync();

        return true;
    }

}