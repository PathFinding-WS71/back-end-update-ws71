using Infrastructure.Model;

namespace Domain.Interfaces;

public interface ICommunityDomain
{
    Task<List<Community>> GetAll();
    public Task<Community> GetById(int id);
    Task<bool> Create(Community communityData); 
    Task<bool> Update(int id, Community communityData );
    Task<bool> Delete(int id);
}