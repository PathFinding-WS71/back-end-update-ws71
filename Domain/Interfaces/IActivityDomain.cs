using Infrastructure.Model;

namespace Domain.Interfaces;

public interface IActivityDomain
{
    Task<List<Activity>> GetAll();
    public Task<Activity> GetById(int id);
    Task<bool> Create(Activity activityData); 
    Task<bool> Update(int id, Activity activityData );
    Task<bool> Delete(int id);
}