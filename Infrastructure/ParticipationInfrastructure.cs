using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ParticipationInfrastructure : IParticipationInfrastructure
{
    private readonly UpdateDbContext _updateDbContext;
    public ParticipationInfrastructure(UpdateDbContext updateDbContext)
    {
        _updateDbContext = updateDbContext;
    }

    public async Task<List<Participation>> GetAll()
    {
        return await _updateDbContext.Participations.Where(participation => participation.IsActive).ToListAsync();
    }

    public async Task<Participation> GetById(int id)
    {
        return await _updateDbContext.Participations.SingleAsync(participation =>
                participation.IsActive && participation.Id == id);
    }

    public async Task<bool> Create(Participation participationData)
    {
        try
        {
            participationData.IsActive = true;

            await _updateDbContext.Participations.AddAsync(participationData);
            await _updateDbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> Update(int id, Participation participationData)
    {
        try
        {
            var participation = await _updateDbContext.Participations.FindAsync(id);
            if (participation == null)
            {
                Console.WriteLine("Participation doesn't exist");
                return false;
            }
            
            participation.ActivityId = participationData.ActivityId;

            _updateDbContext.Participations.Update(participation);
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
        var participation = await _updateDbContext.Participations.FindAsync(id);
        if (participation == null)
        {
            Console.WriteLine("Participation doesn't exist");
            return false;
        }

        participation.IsActive = false;

        _updateDbContext.Participations.Update(participation);
        await _updateDbContext.SaveChangesAsync();

        return true;
    }
}