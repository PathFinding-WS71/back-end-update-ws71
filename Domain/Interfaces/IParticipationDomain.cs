using Infrastructure.Model;

namespace Domain.Interfaces;

public interface IParticipationDomain
{
    Task<List<Participation>> GetAll();
    public Task<Participation> GetById(int id);
    Task<bool> Create(Participation participationData);
    Task<bool> Update(int id, Participation participationData);
    Task<bool> Delete(int id);
}