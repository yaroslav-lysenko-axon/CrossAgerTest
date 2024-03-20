using CrossAgerTest.Domain.Contexts;
using CrossAgerTest.Domain.Models.DbEntities;
using CrossAgerTest.Domain.Models.Enums;
using CrossAgerTest.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CrossAgerTest.Domain.Repositories;

public class ClientsGroupRepository(CrossAgerDbContext context)
    : GenericRepository<ClientsGroup>(context.ClientsGroups), IClientsGroupRepository
{
    public async Task<List<ClientsGroup>> WaitingClientsGroupsSortedByArrival(int emptyChairs)
    {
        IQueryable<ClientsGroup> clientsGroups = context.ClientsGroups
            .AsNoTracking()
            .Where(clientsGroup => clientsGroup.State == ClientsGroupState.Waiting && clientsGroup.Size <= emptyChairs)
            .OrderBy(clientsGroup => clientsGroup.ArrivedAt);

        return await clientsGroups.ToListAsync();
    }
}