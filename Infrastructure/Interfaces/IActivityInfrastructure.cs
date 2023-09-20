using Infrastructure.Model;

namespace Infrastructure.Interfaces;


public interface IActivityInfrastructure
{
    Task<List<Activity>> GetAll();
    public Task<Activity> GetById(int id);
    Task<bool> Create(Activity activityData); 
    Task<bool> Update(int id, Activity activityData );
    Task<bool> Delete(int id);
    
}