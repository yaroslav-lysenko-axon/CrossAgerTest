using CrossAgerTest.Domain.Models.Dtos;

namespace CrossAgerTest.Domain.Services.Abstractions;

public interface IRestManagerService
{
    Task<IReadOnlyCollection<TableDto>> GetTables(); 

    Task<ClientsGroupDto> OnArrive(ClientsGroupDto clientsGroupDto);

    ClientsGroupDto Lookup(int id);
    
    Task<ClientsGroupDto> OnLeave(int id);
}