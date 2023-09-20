using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace Domain;

public class CommunityMemberDomain : ICommunityMemberDomain
{
    private readonly ICommunityMemberInfrastructure _communityMemberInfrastructure;

    public CommunityMemberDomain(ICommunityMemberInfrastructure communityMemberInfrastructure)
    {
        _communityMemberInfrastructure = communityMemberInfrastructure;
    }

    public async Task<List<CommunityMember>> GetAll()
    {
        return await _communityMemberInfrastructure.GetAll();
    }

    public async Task<CommunityMember> GetById(int id)
    {
        return await _communityMemberInfrastructure.GetById(id);
    }

    public async Task<bool> Create(CommunityMember communityMemberData)
    {
        return await _communityMemberInfrastructure.Create(communityMemberData);
    }

    public async Task<bool> Update(int id, CommunityMember communityMemberData)
    {
        return await _communityMemberInfrastructure.Update(id, communityMemberData);
    }

    public async Task<bool> Delete(int id)
    {
        return await _communityMemberInfrastructure.Delete(id);
    }
}