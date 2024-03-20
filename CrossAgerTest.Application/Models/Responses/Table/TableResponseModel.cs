using CrossAgerTest.Application.Models.Responses.ClientsGroup;

namespace CrossAgerTest.Application.Models.Responses.Table;

public class TableResponseModel
{
    public int Id { get; set; }
    public int Size { get; set; }
    public int EmptyChairs { get; set; }
    public IReadOnlyCollection<ClientsGroupResponseModel> ClientsGroups { get; set; }
}