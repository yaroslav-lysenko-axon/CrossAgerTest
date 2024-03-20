using CrossAgerTest.Domain.Models.Enums;

namespace CrossAgerTest.Domain.Models.Dtos;

public class ClientsGroupDto
{
    public int Id { get; set; }
    public int? TableId { get; set; }
    public int Size { get; set; }
    public ClientsGroupState State { get; set; }
    public DateTime ArrivedAt { get; set; } = DateTime.UtcNow;
    public TableDto Table { get; set; }
}