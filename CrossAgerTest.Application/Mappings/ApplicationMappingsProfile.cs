using AutoMapper;
using CrossAgerTest.Application.Models.Requests.ClientsGroup;
using CrossAgerTest.Application.Models.Responses.ClientsGroup;
using CrossAgerTest.Application.Models.Responses.Table;
using CrossAgerTest.Domain.Models.Dtos;

namespace CrossAgerTest.Application.Mappings;

public class ApplicationMappingsProfile : Profile
{
    public ApplicationMappingsProfile()
    {
        //request
        CreateMap<CreateClientsGroupRequestModel, ClientsGroupDto>();
        CreateMap<DeleteClientsGroupRequestModel, ClientsGroupDto>();
        
        //response
        CreateMap<TableDto, TableResponseModel>();
        CreateMap<ClientsGroupDto, ClientsGroupResponseModel>();
    }
}