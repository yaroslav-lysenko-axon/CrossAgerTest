namespace CrossAgerTest.Domain.Models.Dtos;

public class TableDto
{
    public int Id { get; set; }
    public int Size { get; set; }
    public int EmptyChairs { get; set; }
    public IReadOnlyCollection<ClientsGroupDto> ClientsGroups { get; set; }
}