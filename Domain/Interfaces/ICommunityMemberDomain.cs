using Infrastructure.Model;

namespace Domain.Interfaces;

public interface ICommunityMemberDomain
{
    Task<List<CommunityMember>> GetAll();
    public Task<CommunityMember> GetById(int id);
    Task<bool> Create(CommunityMember communityMemberData); 
    Task<bool> Update(int id, CommunityMember communityMemberData );
    Task<bool> Delete(int id);
}