using AutoMapper;
using CrossAgerTest.Domain.Models.DbEntities;
using CrossAgerTest.Domain.Models.Dtos;
using CrossAgerTest.Domain.Models.Enums;
using CrossAgerTest.Domain.Repositories.Abstractions;
using CrossAgerTest.Domain.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CrossAgerTest.Domain.Services;

public class RestManagerService(
    ITableRepository tableRepository,
    IClientsGroupRepository clientsGroupRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRestManagerService
{
    public async Task<IReadOnlyCollection<TableDto>> GetTables()
    {
        var tables = await tableRepository.FindAll(table =>
            table.ClientsGroups.Where(cg => cg.State == ClientsGroupState.Seated));

        return mapper.Map<List<TableDto>>(tables);
    }

    public async Task<ClientsGroupDto> OnArrive(ClientsGroupDto clientsGroupDto)
    {
        var clientsGroup = mapper.Map<ClientsGroup>(clientsGroupDto);
        clientsGroup.State = ClientsGroupState.Waiting;
        
        clientsGroup = await UpdateOccupiedChairsAtTables(clientsGroup);
        
        EntityEntry<ClientsGroup> result = await clientsGroupRepository.InsertAsync(clientsGroup);

        await unitOfWork.Commit();

        return mapper.Map<ClientsGroupDto>(result.Entity);
    }

    public ClientsGroupDto Lookup(int id)
    {
        ClientsGroup clientsGroup = clientsGroupRepository.FindFirst(clientsGroup => clientsGroup.Id == id,
            x => x.Include(clientsGroup => clientsGroup.Table), true);

        return mapper.Map<ClientsGroupDto>(clientsGroup);
    }

    public async Task<ClientsGroupDto> OnLeave(int id)
    {
        var clientsGroup = clientsGroupRepository.FindFirst(clientsGroup => clientsGroup.Id == id);
        clientsGroup.State = ClientsGroupState.Completed;
        
        clientsGroup = await UpdateOccupiedChairsAtTables(clientsGroup);
        
        EntityEntry<ClientsGroup> result = clientsGroupRepository.Update(clientsGroup);

        
        await unitOfWork.Commit();

        return mapper.Map<ClientsGroupDto>(result.Entity);
    }

    private async Task<ClientsGroup> UpdateOccupiedChairsAtTables(ClientsGroup clientsGroup)
    {
        var tables = await tableRepository.FindAll();
        
        Table? tableToUpdate = new();

        if (clientsGroup.State == ClientsGroupState.Waiting)
        {
            tableToUpdate = tables.FirstOrDefault(table => table.Size - table.EmptyChairs == 0 && table.Size >= clientsGroup.Size);
            if (tableToUpdate != null)
            {
                clientsGroup.TableId = tableToUpdate.Id;
                clientsGroup.State = ClientsGroupState.Seated;
                tableToUpdate.EmptyChairs -= clientsGroup.Size;
            }
            else if (tables.Count(table => table.EmptyChairs >= clientsGroup.Size) > 0)
            {
                tableToUpdate = tables.Where(table => table.EmptyChairs >= clientsGroup.Size).MinBy(table => table.EmptyChairs);
                if (tableToUpdate != null)
                {
                    clientsGroup.TableId = tableToUpdate.Id;
                    clientsGroup.State = ClientsGroupState.Seated;
                    tableToUpdate.EmptyChairs -= clientsGroup.Size;
                }
            }
        }

        if (clientsGroup.State == ClientsGroupState.Completed)
        {
            tableToUpdate = tables.FirstOrDefault(table => table.Id == clientsGroup.TableId);
            if (tableToUpdate != null)
            {
                tableToUpdate.EmptyChairs += clientsGroup.Size;

                var waitingClientsGroups =
                    await clientsGroupRepository.WaitingClientsGroupsSortedByArrival(tableToUpdate.EmptyChairs);
                
                List<ClientsGroup> clientsGroups = new List<ClientsGroup>();
                
                foreach (var waitingClientsGroup in waitingClientsGroups)
                {
                    if (tableToUpdate.EmptyChairs - waitingClientsGroup.Size < 0)
                    {
                        continue;
                    }

                    tableToUpdate.EmptyChairs -= waitingClientsGroup.Size;
                    waitingClientsGroup.TableId = tableToUpdate.Id;
                    waitingClientsGroup.State = ClientsGroupState.Seated;
                    clientsGroups.Add(waitingClientsGroup);

                    if (tableToUpdate.EmptyChairs == 0)
                    {
                        break;
                    }
                }
                
                if (clientsGroups.Count > 0)
                {
                    clientsGroupRepository.UpdateRange(clientsGroups);
                }
            }
        }

        if (tableToUpdate != null)
        {
            tableRepository.Update(tableToUpdate);
        }

        return clientsGroup;
    }
}