using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace Domain;

public class ParticipationDomain : IParticipationDomain
{
    private readonly IParticipationInfrastructure _participationInfrastructure;

    public ParticipationDomain(IParticipationInfrastructure participationInfrastructure)
    {
        _participationInfrastructure = participationInfrastructure;
    }

    public async Task<List<Participation>> GetAll()
    {
        return await _participationInfrastructure.GetAll();
    }

    public async Task<Participation> GetById(int id)
    {
        return await _participationInfrastructure.GetById(id);
    }

    public async Task<bool> Create(Participation participationData)
    {
        return await _participationInfrastructure.Create(participationData);
    }

    public async Task<bool> Update(int id, Participation participationData)
    {
        return await _participationInfrastructure.Update(id, participationData);
    }

    public async Task<bool> Delete(int id)
    {
        return await _participationInfrastructure.Delete(id);
    }
}