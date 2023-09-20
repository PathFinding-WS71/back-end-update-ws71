using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class CommunityMemberInfrastructure : ICommunityMemberInfrastructure
{
    private readonly UpdateDbContext _updateDbContext;

    public CommunityMemberInfrastructure(UpdateDbContext updateDbContext)
    {
        _updateDbContext = updateDbContext;
    }

    public async Task<List<CommunityMember>> GetAll()
    {
        return await _updateDbContext.CommunityMembers.Where(communityMember => communityMember.IsActive).ToListAsync();
    }

    public async Task<CommunityMember> GetById(int id)
    {
        return await _updateDbContext.CommunityMembers.SingleAsync(communityMember =>
            communityMember.IsActive && communityMember.Id == id);
    }

    public async Task<bool> Create(CommunityMember communityMemberData)
    {
        try
        {
            await _updateDbContext.CommunityMembers.AddAsync(communityMemberData);
            await _updateDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> Update(int id, CommunityMember communityMemberData)
    {
        var communityMember = await _updateDbContext.CommunityMembers.FindAsync(id);
        if (communityMember == null)
            return false;
        communityMember.MembershipDate = DateOnly.FromDateTime(DateTime.Now);
        communityMember.CommunityId = communityMemberData.CommunityId;
        communityMember.RoleId = communityMemberData.RoleId;
        communityMember.DateUpdated = DateTime.Now;
        _updateDbContext.CommunityMembers.Update(communityMember);
        await _updateDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var communityMember = await _updateDbContext.CommunityMembers.FindAsync(id);
        if (communityMember == null)
            return false;
        communityMember.IsActive = false;
        _updateDbContext.CommunityMembers.Update(communityMember);
        await _updateDbContext.SaveChangesAsync();

        return true;
    }
}