using CrossAgerTest.Application.Models.Responses.Table;
using CrossAgerTest.Domain.Models.Enums;

namespace CrossAgerTest.Application.Models.Responses.ClientsGroup;

public class ClientsGroupResponseModel
{
    public int Id { get; set; }
    public int? TableId { get; set; }
    public int Size { get; set; }
    public ClientsGroupState State { get; set; }
    public DateTime ArrivedAt { get; set; }
    public TableResponseModel Table { get; set; }
}