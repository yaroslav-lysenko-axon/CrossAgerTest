using AutoMapper;
using CrossAgerTest.Domain.Models.DbEntities;
using CrossAgerTest.Domain.Models.Dtos;

namespace CrossAgerTest.Domain.Mappings;

public class DomainMappingsProfile : Profile
{
    public DomainMappingsProfile()
    {
        CreateMap<Table, TableDto>();
        CreateMap<ClientsGroup, ClientsGroupDto>();
        
        CreateMap<TableDto, Table>();
        CreateMap<ClientsGroupDto, ClientsGroup>();
    }
}