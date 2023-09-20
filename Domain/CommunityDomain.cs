using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace Domain;

public class CommunityDomain : ICommunityDomain
{
    private readonly ICommunityInfrastructure _communityInfrastructure;
    
    public CommunityDomain(ICommunityInfrastructure communityInfrastructure)
    {
        _communityInfrastructure = communityInfrastructure;
    }

    public async Task<List<Community>> GetAll()
    {
        return await _communityInfrastructure.GetAll();
    }

    public async Task<Community> GetById(int id)
    {
        return await _communityInfrastructure.GetById(id);
    }

    public async Task<bool> Create(Community communityData)
    {
        return await _communityInfrastructure.Create(communityData);
    }

    public async Task<bool> Update(int id, Community communityData)
    {
        return await _communityInfrastructure.Update(id, communityData);
    }

    public async Task<bool> Delete(int id)
    {
        return await _communityInfrastructure.Delete(id);
    }
}