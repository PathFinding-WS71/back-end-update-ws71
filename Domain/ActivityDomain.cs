using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace Domain;

public class ActivityDomain: IActivityDomain
{
    private readonly IActivityInfrastructure _activityInfrastructure;

    public ActivityDomain(IActivityInfrastructure activityInfrastructure)
    {
        _activityInfrastructure = activityInfrastructure;
    }

    public async Task<List<Activity>> GetAll()
    {
        return await _activityInfrastructure.GetAll();
    }

    public async Task<Activity> GetById(int id)
    {
        return await _activityInfrastructure.GetById(id);
    }

    public async Task<bool> Create(Activity activityData)
    {
        return await _activityInfrastructure.Create(activityData);
    }

    public async Task<bool> Update(int id, Activity activityData)
    {
        return await _activityInfrastructure.Update(id, activityData);
    }

    public async Task<bool> Delete(int id)
    {
        return await _activityInfrastructure.Delete(id);
    }
}