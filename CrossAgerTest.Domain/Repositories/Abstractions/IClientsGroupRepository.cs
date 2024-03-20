using CrossAgerTest.Domain.Models.DbEntities;

namespace CrossAgerTest.Domain.Repositories.Abstractions;

public interface IClientsGroupRepository : IGenericRepository<ClientsGroup>
{
    public Task<List<ClientsGroup>> WaitingClientsGroupsSortedByArrival(int emptyChairs);
}